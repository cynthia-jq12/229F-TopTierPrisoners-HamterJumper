using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Transform playerTransform;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;

    private float highestY = 0f;
    private int currentScore = 0;

    void Awake() { Instance = this; }

    void Update()
    {
        if (playerTransform != null && Time.timeScale > 0)
        {
            if (playerTransform.position.y > highestY)
            {
                highestY = playerTransform.position.y;
                currentScore = Mathf.FloorToInt(highestY);
                scoreText.text = "High: " + currentScore + "m";

                if (currentScore > PlayerPrefs.GetInt("HighScore", 0))
                {
                    PlayerPrefs.SetInt("HighScore", currentScore);
                    PlayerPrefs.Save();
                }
            }
        }
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}