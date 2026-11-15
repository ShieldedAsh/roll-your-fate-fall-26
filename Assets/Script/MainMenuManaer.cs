using UnityEngine;

public class MainMenuManaer : MonoBehaviour
{
    public string gameScene = "LevelAlphaScene";
    public void _StartGame()
    {
        _LoadSceneManual(gameScene);
    }
    public void _QuitGame()
    {
        Application.Quit();
    }
    /// <summary>
    /// for use in ui buttons, lets them load a scene
    /// </summary>
    /// <param name="buildIndex">which scene to load</param>
    public void _LoadSceneManual(int buildIndex)
    {
        SceneLoader.Instance.LoadScene(buildIndex);
    }
    /// <summary>
    /// for UI buttons, lets them load a scene
    /// </summary>
    /// <param name="sceneName">which scene to load</param>
    public void _LoadSceneManual(string sceneName)
    {
        SceneLoader.Instance.LoadScene(sceneName);
    }
}
