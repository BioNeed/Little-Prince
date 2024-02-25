using UnityEngine;

public class BellCollision : MonoBehaviour
{
    [SerializeField] private Bell _bell;
    [SerializeField] private Animator _bellAnimator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            _bell.RingBell();
            _bellAnimator.SetTrigger("IsRinging");
        }
    }
}
