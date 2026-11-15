using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{

    [SerializeField]
    [Tooltip("the name of the loading scene (cause then we can change the scene order without breaking everything)")]
    private string loadingScene = "LoadingScreen";
    private int loadingSceneIndex = -1;

    [Tooltip("a 0.0f-1.0f float saying how far along loading the scene we are")]
    public float LoadingPercent { get { return loadingPercent; } }
    [Tooltip("returns true if we are in the loading scene, otherwise returns false")]
    public bool InLoadingScene { get { return inLoadingScene; } }

    [Tooltip("gets the current instance of the sceneloader")]
    public static SceneLoader Instance;
    private AsyncOperation loading;

    private TextMeshProUGUI percenttext;
    private Slider sliderDisplay;
    private bool wantToLoadScene = false;

    private float loadingPercent = 0;
    private bool inLoadingScene = false;

    private int si = 0;
    private void Awake()
    {
        //get the current instance
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(this);
        loadingSceneIndex = SceneManager.GetSceneByName(loadingScene).buildIndex;
    }

    private void Update()
    {
        //code runs to get us to the loading scene
        if (wantToLoadScene && !inLoadingScene)
        {
            inLoadingScene = SceneManager.GetActiveScene().name == loadingScene;
            //once we are in the loading scene, get us some display stuff and prep the loading into the scene we actually want to go to
            if (inLoadingScene)
            {
                percenttext = FindFirstObjectByType<TextMeshProUGUI>();
                sliderDisplay = FindFirstObjectByType<Slider>();

                loading = SceneManager.LoadSceneAsync(si);
                wantToLoadScene = false;
            }
        }
        else if (inLoadingScene)
        {
            //code runs when we are waiting for the scene to loads
            if (!loading.isDone)
            {
                //while loadingpercent goes from 0-1, the values .9-1 are taken up by stuff that doesn't actually do anything, so to make it look more correct, just do this
                loadingPercent = Mathf.Clamp01(loading.progress / .9f);

                if (percenttext != null)
                    percenttext.text = $"{Mathf.Floor(loadingPercent * 10000) / 100}%";
                if (sliderDisplay != null)
                    sliderDisplay.value = loadingPercent;
            }
            //wraps up the loading screen and finishes loading into the correct scene, plus clears data we don't need anymore
            else
            {
                inLoadingScene = false;
                loadingPercent = 0;
                loading = default;
                percenttext = null;
                sliderDisplay = null;
                si = 0;
            }
        }
    }

    /// <summary>
    /// loads a scene based on it's scene build index
    /// </summary>
    /// <param name="sceneIndex">the build index of the scene we want to load</param>
    /// <exception cref="System.InvalidOperationException">don't load the loading scene</exception>
    public void LoadScene(int sceneIndex)
    {
        if (sceneIndex == loadingSceneIndex)
        {
            Debug.Log(loadingSceneIndex);
            throw new System.InvalidOperationException("trying to load into the loading scene is not permitted!");
        }
        si = sceneIndex;
        wantToLoadScene = true;
        SceneManager.LoadScene(loadingScene);
    }
    /// <summary>
    /// loads a scene based on it's scene name
    /// </summary>
    /// <param name="sceneName">the name of the scene we want to load</param>
    /// /// <exception cref="System.InvalidOperationException">don't load the loading scene</exception>
    public void LoadScene(string sceneName)
    {
        LoadScene(SceneManager.GetSceneByName(sceneName).buildIndex);
    }
}
