using UnityEngine;
using UnityEngine.SceneManagement;

public class StartingPoint : MonoBehaviour
{
    public void MenuScene()
    {
        SceneManager.LoadScene(0);
    }
    public void GameScene()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
