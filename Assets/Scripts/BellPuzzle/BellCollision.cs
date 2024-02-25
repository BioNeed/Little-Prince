using UnityEngine;

public class BellCollision : MonoBehaviour
{
    [SerializeField] private Bell _bell;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            _bell.RingBell();
        }
    }
}
