using UnityEngine;
using UnityEngine.SceneManagement;

public class GameProgress : MonoBehaviour
{
    [SerializeField] private DisplayScrollText _displayScrollText;

    [TextArea] [SerializeField] private string _messageOnLevelFailure;
    [TextArea] [SerializeField] private string _messageOnLevel1Loaded;
    [TextArea] [SerializeField] private string _messageOnLevel1Finished;
    [TextArea] [SerializeField] private string _messageOnLevel2Loaded;
    [TextArea] [SerializeField] private string _messageOnLevel2Finished;

    public void FinishLevel()
    {
        Time.timeScale = 0;
        var levelNumber = SceneManager.GetActiveScene().buildIndex;
        switch(levelNumber)
        {
            case 1:
                _displayScrollText.DisplayText(_messageOnLevel1Finished, LoadNextLevel);
                break;
            case 2:
                _displayScrollText.DisplayText(_messageOnLevel2Finished, LoadNextLevel);
                break;
        }
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
            loadingLevelNumber = 0;
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
        switch (scene.buildIndex)
        {
            case 1:
                _displayScrollText.DisplayText(_messageOnLevel1Loaded);
                break;
            case 2:
                _displayScrollText.DisplayText(_messageOnLevel2Loaded);
                break;
        }
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
