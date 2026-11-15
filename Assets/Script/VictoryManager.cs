using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryManager : MonoBehaviour
{
    public static string winScreenName = "WinScene";
    /// <summary>
    /// loads the win screen
    /// </summary>
    public static void Win()
    {
        Debug.Log("you win, going to win screen!");
        if (SceneManager.GetSceneByName(winScreenName) != null)
            SceneManager.LoadSceneAsync(winScreenName);
        else
            Debug.LogError($"\"{winScreenName}\" is not a valid scene to load to, make sure it is set up in the build manager!");
    }
}
