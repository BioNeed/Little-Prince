using UnityEngine;
using UnityEngine.SceneManagement;

public class GameProgress : MonoBehaviour
{
    [SerializeField] private DisplayScrollText _displayScrollText;
    [SerializeField] private int _menuSceneNumber;

    [TextArea] [SerializeField] private string _messageOnLevelFailure;
    [TextArea] [SerializeField] private string _messageOnLevelLoaded;
    [TextArea] [SerializeField] private string _messageOnLevelFinished;

    public void FinishLevel()
    {
        Time.timeScale = 0;
        _displayScrollText.DisplayText(_messageOnLevelFinished, LoadNextLevel);
    }

    public void FailLevel()
    {
        Time.timeScale = 0;
        _displayScrollText.DisplayText(_messageOnLevelFailure, RestartLevel);
    }

    private void LoadNextLevel()
    {
        int loadingLevelNumber;
        int levelNumber = SceneManager.GetActiveScene().buildIndex;
        if (levelNumber + 1 == SceneManager.sceneCountInBuildSettings)
        {
            loadingLevelNumber = _menuSceneNumber;
        }
        else
        {
            loadingLevelNumber = levelNumber + 1;
        }

        SceneManager.LoadScene(loadingLevelNumber);
    }

    private void RestartLevel()
    {
        var levelNumber = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(levelNumber);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        Time.timeScale = 0;
        _displayScrollText.DisplayText(_messageOnLevelLoaded);
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
