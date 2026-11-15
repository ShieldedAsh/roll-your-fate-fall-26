using UnityEngine;

public class MainMenuManaer : MonoBehaviour
{
    public int gameScene = 2;
    public void _StartGame()
    {
        SceneLoader.Instance.LoadScene(gameScene);
    }
    public void _QuitGame()
    {
        Application.Quit();
    }
}
