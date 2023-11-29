using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // Singleton instance

    private int currentScore = 0; // Current score

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
             DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // Ensures only one instance exists
        }
    }

     public int GetCurrentScore()
    {
        return currentScore;
    }

    // Function to update the score
    public void UpdateScore(int points)
    {
        currentScore += points;
        Debug.Log(currentScore);
    }

    // Function to transition to the next level or back to the main menu
    public void NextLevelOrMainMenu(string nextSceneName)
    {
        // Save the current score as a high score using PlayerPrefs
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (currentScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
        }

        Debug.Log(PlayerPrefs.GetInt("HighScore", 0));
        SceneManager.LoadScene(nextSceneName);
       
    }
}