using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandle : MonoBehaviour
{
    public void Game() { SceneManager.LoadScene("HamsterJumper"); }
    public void Credit() { SceneManager.LoadScene("CreditScene"); }
    public void Menu() { SceneManager.LoadScene("MainMenu"); }
    public void Restart() { SceneManager.LoadScene(SceneManager.GetActiveScene().name); }
}