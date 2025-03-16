using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

public class PulseToBeat : MonoBehaviour
{
    [SerializeField] VisualEffect _sporeEffect;
    [SerializeField] float _pulseSize = 1.15f;
    [SerializeField] float _returnSpeed = 5f;
    private Vector3 _startSize;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _startSize = transform.localScale;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, _startSize, Time.deltaTime * _returnSpeed);
    }

    public void Pulse()
    {
        PlayParticle();
        transform.localScale = _startSize * _pulseSize;
    }

    void PlayParticle()
    {
        _sporeEffect.Play();  // Play the particle effect when spacebar is pressed
    }
}
