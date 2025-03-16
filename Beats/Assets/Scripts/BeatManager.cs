using UnityEngine;
using UnityEngine.Events;

public class BeatManager : MonoBehaviour
{
    [SerializeField] private float _bpm;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Beats[] _beats;

    private void Update()
    {
        foreach (Beats beat in _beats)
        {
            /*
             * sampledTime represents the current position in the audio, measured in samples.
             * _audioSource.clip.frequency * beatLength gives you the number of samples per beat.
             * _audioSource.timeSamples gives you the exact position (in samples) of where the audio is currently playing.
             * (_audioSource.timeSamples / numberOfSamplesPerBeat) gives you the current beat's position in the audio.
             */
            float sampledTime = (_audioSource.timeSamples / (_audioSource.clip.frequency * beat.GetBeatLength(_bpm)));
            beat.CheckForNewBeat(sampledTime);
        }
    }
}

[System.Serializable]
public class Beats
{
    [SerializeField] private float _magnifier; // Adjust the rate of the beat: 1 is normal, 0.5 half speed, 2 is double speed
    [SerializeField] private UnityEvent _trigger;
    private int _lastBeat;

    public float GetBeatLength(float bpm) // determines the amount of beats happening each second
    {
        return 60f / (bpm * _magnifier);
    }

    public void CheckForNewBeat(float currentbeat)
    {
        if (Mathf.FloorToInt(currentbeat) != _lastBeat)
        {
            _lastBeat = Mathf.FloorToInt(currentbeat);
            _trigger.Invoke();
        }
    }
}