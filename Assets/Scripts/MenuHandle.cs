using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuHandle : MonoBehaviour
{
    public static MenuHandle Instance;
    public TextMeshProUGUI highScoreText;

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    void Start()
    {
        UpdateScoreDisplay();
    }

    public void UpdateScoreDisplay()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        if (highScoreText != null)
        {
            highScoreText.text = "Best High: " + highScore + "m";
        }
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        PlayerPrefs.Save();
        UpdateScoreDisplay();
    }

    public void Game() { Time.timeScale = 1f; SceneManager.LoadScene("HamsterJumper"); }
    public void Credit() { SceneManager.LoadScene("CreditScene"); }
    public void Menu() { SceneManager.LoadScene("MainMenu"); }
    public void Restart() { Time.timeScale = 1f; SceneManager.LoadScene(SceneManager.GetActiveScene().name); }
}