using System;
using TMPro;
using UnityEngine;

public class DisplayScrollText : MonoBehaviour
{  
    [SerializeField] private GameObject _scroll;
    [SerializeField] private TMP_Text _text;

    private bool _isDisplaying = false;
    private Action _callbackAfterResuming;

    public void DisplayText(string message, Action callbackAfterResuming = null)
    {
        _text.text = message;
        _scroll.SetActive(true);
        _isDisplaying = true;
        _callbackAfterResuming = callbackAfterResuming;
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
        _callbackAfterResuming?.Invoke();
    }
}
