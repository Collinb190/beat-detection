using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Singleton pattern to access ScoreManager from any other script
    public static ScoreManager instance;

    private int score = 0;

    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake()
    {
        // Singleton setup
        if (instance == null) instance = this;
        else Destroy(gameObject);

        // Ensure the scoreText is assigned
        if (scoreText == null)
        {
            Debug.LogError("ScoreManager: No TextMeshProUGUI assigned!");
        }
    }

    // Method to add score
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    // Method to update the score text UI
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
