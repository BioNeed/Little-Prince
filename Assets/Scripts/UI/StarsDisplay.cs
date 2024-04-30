using UnityEngine;
using TMPro;

public class StarsDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _starsCounter;

    public void DisplayStars(int starsCount, int starsToSucceed)
    {
        string text;
        if (starsCount >= starsToSucceed)
        {
            text = "Отличная работа!";
        }
        else
        {
            text = $"{starsCount} / {starsToSucceed}";
        }

        _starsCounter.text = text;
    }
}
