using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject gameOverPanel;
    public TextMeshProUGUI pointText;
    private int score = 0;

    void Awake() { Instance = this; }

    public void AddScore(int points)
    {
        score += points;
        pointText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}