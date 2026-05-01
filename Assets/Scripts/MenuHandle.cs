using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandle : MonoBehaviour
{
    public void Game() { Time.timeScale = 1f; SceneManager.LoadScene("HamsterJumper"); }
    public void Credit() { SceneManager.LoadScene("CreditScene"); }
    public void Menu() { SceneManager.LoadScene("MainMenu"); }
    public void Restart() { Time.timeScale = 1f; SceneManager.LoadScene(SceneManager.GetActiveScene().name); }
}