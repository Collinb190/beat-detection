using UnityEngine;
using UnityEngine.VFX;

public class TestSporePlay : MonoBehaviour
{
    [SerializeField] VisualEffect _sporeEffect;

    // Update is called once per frame
    void Update()
    {
        PlayParticle();
    }

    void PlayParticle()
    {
        // Check if the spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _sporeEffect.Play();  // Play the particle effect when spacebar is pressed
        }
    }
}
