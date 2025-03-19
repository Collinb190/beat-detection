using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Nature");
    }

    public void QuitGame()
    {
        Debug.Log("Stopped the game");
        Application.Quit();
    }
}