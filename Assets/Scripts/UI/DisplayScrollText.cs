using TMPro;
using UnityEngine;

public class DisplayScrollText : MonoBehaviour
{
    [SerializeField] private GameProgress _gameProgress;   
    [SerializeField] private GameObject _scroll;
    [SerializeField] private TMP_Text _text;

    private bool _isDisplaying = false;
    private bool _isFinish = false;

    public void DisplayText(string message)
    {
        _text.text = message;
        _scroll.SetActive(true);
        _isDisplaying = true;
    }

    public void DisplayTextBeforeLevelFinish(string message)
    {
        _text.text = message;
        _scroll.SetActive(true);
        _isDisplaying = true;
        _isFinish = true;
    }

    private void Update()
    {
        if (_isDisplaying == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ResumeGame();
            }
        }
    }

    private void ResumeGame()
    {
        _scroll.SetActive(false);
        _isDisplaying = false;
        Time.timeScale = 1f;

        if (_isFinish == true)
        {
            _gameProgress.LoadNextLevel();
            _isFinish = false;
        }
    }
}
