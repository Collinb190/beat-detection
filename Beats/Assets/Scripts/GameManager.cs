using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioSource gameAudio; // Reference to your AudioSource

    void Update()
    {
        if (gameAudio != null && !gameAudio.isPlaying) EndGame();
    }

    void EndGame()
    {
        Debug.Log("Game Over! Audio Finished.");
        Time.timeScale = 0;
    }
}
