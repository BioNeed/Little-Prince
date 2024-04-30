using UnityEngine;

public class StarCollecting : MonoBehaviour
{
    [SerializeField] private StarsCollectingProgress _starsCollectingProgress;
    [SerializeField] private StarCollectingSounds _sounds; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Star>() != null)
        {
            _starsCollectingProgress.CollectStar();
            _sounds.PlayCoinPickup();
            Destroy(collision.gameObject);
        }
    }
}
