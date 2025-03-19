using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioSource gameAudio; // Reference to your AudioSource
    [SerializeField] private GameObject gameOverUI; // Reference to the UI panel
    [SerializeField] private GameObject arrowSpawner;
    [SerializeField] private GameObject target;

    void Update()
    {
        if (gameAudio != null && !gameAudio.isPlaying) EndGame();
    }

    void EndGame()
    {
        gameOverUI.SetActive(true); // Show the UI when the audio stops
        arrowSpawner.SetActive(false);
        target.SetActive(false);
    }
    public void QuitGame()
    {
        Debug.Log("Stopped the game");
        Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
