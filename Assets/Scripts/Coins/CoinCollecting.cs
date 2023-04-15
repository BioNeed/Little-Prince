using UnityEngine;

public class CoinCollecting : MonoBehaviour
{
    [SerializeField] private CoinsDisplay _coinsDisplay;

    private int _coinsCollected = 0;   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Coin>() != null)
        {
            _coinsCollected++;
            _coinsDisplay.DisplayCoins(_coinsCollected);
            Destroy(collision.gameObject);
        }
    }
}
