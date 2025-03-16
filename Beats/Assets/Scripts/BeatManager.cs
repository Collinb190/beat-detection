using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.VFX;

public class BeatManager : MonoBehaviour
{
    [SerializeField] private float _bpm;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Beats[] _beats;

    private void Update()
    {
        foreach (Beats beat in _beats)
        {
            float sampledTime = (_audioSource.timeSamples / (_audioSource.clip.frequency * beat.GetBeatLength(_bpm)));
            beat.CheckForNewBeat(sampledTime);
        }
    }
}

[System.Serializable]
public class Beats
{
    [SerializeField] private float _interval;
    [SerializeField] private UnityEvent _trigger;
    private int _lastBeat;

    public float GetBeatLength(float bpm)
    {
        return 60f / (bpm * _interval);
    }

    public void CheckForNewBeat (float beat)
    {
        if (Mathf.FloorToInt(beat) != _lastBeat)
        {
            _lastBeat = Mathf.FloorToInt(beat);
            _trigger.Invoke();
        }
    }
}