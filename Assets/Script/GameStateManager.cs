using UnityEngine;
using System.Collections;

public enum GameState
{
    MainMenu,
    Playing,
    Pause,
    GameOver
}

public class GameStateManager : MonoBehaviour
{
    public int delay = 1;

    public static GameStateManager instance;

    public GameObject mainMenuUI;
    public GameObject inGameMenuUI;
    public GameObject GameOverMenuUI;
    public GameObject PauseMenuUI;

    public GameState currentGameState { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Time.timeScale = 0;
        ChangeState(GameState.MainMenu);
    }

    public void ChangeState(GameState newState)
    {
        if (currentGameState == newState) return;

        StartCoroutine(TransitionToState(newState));
    }

    public void ChangeToMainMenu()
    {
        Time.timeScale = 0;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        ChangeState(GameState.MainMenu);
    }

    public void ChangeToPlaying()
    {
        ChangeState(GameState.Playing);
    }

    public void ChangeToPause()
    {
        ChangeState(GameState.Pause);
    }

    public void ChangeToGameOver()
    {
        ChangeState(GameState.GameOver);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        ChangeState(GameState.Playing);
    }

    private IEnumerator TransitionToState(GameState newState)
    {
        if(newState != GameState.MainMenu)
        {
            yield return new WaitForSecondsRealtime(delay);
        }
        currentGameState = newState;
        HandleStateChange();
    }

    private void HandleStateChange()
    {
        HideAllMenu();

        switch (currentGameState)
        {
            case GameState.MainMenu:
                mainMenuUI.SetActive(true);
                Time.timeScale = 0;
                AudioManager.instance.PlayMusic(AudioManager.instance.menuMusic);
                break;
            case GameState.Pause:
                PauseMenuUI.SetActive(true);
                Time.timeScale = 0;
                AudioManager.instance.PlayMusic(AudioManager.instance.menuMusic);
                break;
            case GameState.GameOver:
                GameOverMenuUI.SetActive(true);
                Time.timeScale = 0;
                AudioManager.instance.PlayMusic(AudioManager.instance.menuMusic);
                break;
            case GameState.Playing:
                inGameMenuUI.SetActive(true);
                Time.timeScale = 1;
                AudioManager.instance.PlayMusic(AudioManager.instance.inGameMusic);
                break;
        }
    }

    private void HideAllMenu(){
        mainMenuUI.SetActive(false);
        PauseMenuUI.SetActive(false);
        GameOverMenuUI.SetActive(false);
        inGameMenuUI.SetActive(false);
    }

}
