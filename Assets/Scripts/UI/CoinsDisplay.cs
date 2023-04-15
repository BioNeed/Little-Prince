using UnityEngine;
using TMPro;

public class CoinsDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinsCounter;

    public void DisplayCoins(int coinsCount)
    {
        _coinsCounter.text = coinsCount.ToString();
    }
}
