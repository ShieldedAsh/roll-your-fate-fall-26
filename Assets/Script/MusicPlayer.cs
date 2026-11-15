using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Plays music based on a couple states.
/// THIS IS A SINGLETON!!!
/// </summary>
public class MusicPlayer : MonoBehaviour
{
    /// <summary>
    /// Instance of the MusicPlayer singleton for other things to reference
    /// </summary>
    public static MusicPlayer Instance
    { 
        get; 
        private set; 
    }

    [Tooltip("Reference to the MusicPlayer's AudioSource")]
    [SerializeField]
    private AudioSource _audioSource;

    [Tooltip("Music to play on the main menu")]
    [SerializeField]
    private AudioClip _mainMenu;
    public AudioClip MainMenuMusic
    {
        get { return _mainMenu; }
    }

    [Tooltip("Music to play on the death screen")]
    [SerializeField]
    private AudioClip _deathScreen;
    public AudioClip DeathScreenMusic
    {
        get { return _deathScreen; }
    }

    [Tooltip("Music to play on the win screen, might not be implemented!")]
    [SerializeField]
    private AudioClip _winScreen;
    public AudioClip WinScreenMusic
    {
        get { return _winScreen; }
    }

    [Tooltip("Music to play in the holding cell area")]
    [SerializeField]
    private AudioClip _holdingCell;
    public AudioClip HoldingCellMusic
    {
        get { return _holdingCell; }
    }

    [Tooltip("Music to play in the red area")]
    [SerializeField]
    private AudioClip _redArea;
    public AudioClip RedAreaMusic
    {
        get { return _redArea; }
    }

    [Tooltip("Music to play in the blue area")]
    [SerializeField]
    private AudioClip _blueArea;
    public AudioClip BlueAreaMusic
    {
        get { return _blueArea; }
    }

    /// <summary>
    /// Ensures this is the only MusicPlayer in a scene
    /// </summary>
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Update()
    {
        //Play main menu music on main menu
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            SwapLooped(MainMenuMusic);
        }

        //Play death music on death screen
        else if (SceneManager.GetActiveScene().name == "GaeJover")
        {
            SwapOnce(DeathScreenMusic);
        }

        //Play win music on win screen
        else if (SceneManager.GetActiveScene().name == "WinScene")
        {
            SwapLooped(WinScreenMusic);
        }
    }

    /// <summary>
    /// Plays or swaps a playing track to a track that will be looped.
    /// Assume _audiosource.clip != next when this method is called
    /// </summary>
    /// <param name="next">The next track to play</param>
    public void SwapLooped(AudioClip next)
    {
        _audioSource.Stop();
        _audioSource.loop = true;
        _audioSource.clip = next;
        _audioSource.Play();
    }

    /// <summary>
    /// Plays or swaps a playing track to a track that will play once.
    /// Assume _audiosource.clip != next when this method is called
    /// </summary>
    /// <param name="next">The next track to play</param>
    public void SwapOnce(AudioClip next)
    {
        _audioSource.Stop();
        _audioSource.loop = false;
        _audioSource.clip = next;
        _audioSource.Play();
    }
}
