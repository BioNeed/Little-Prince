using UnityEngine;

public class FloatingPlatformChecker : MonoBehaviour
{
    [SerializeField] private PhysicsMovement _physicsMovement;

    private bool _isFloating = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out FloatingPlatform platform) == true)
        {
            Vector3 collisionPoint = collision.ClosestPoint(transform.position);

            if (collisionPoint.y - collision.bounds.max.y >= GroundChecker.GroundDistance)
            {
                _isFloating = true;
                _physicsMovement.SetPlatformFloating(platform);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out FloatingPlatform platform) == true)
        {
            if (_isFloating == true)
            {
                _physicsMovement.SetPlatformFloating(null);
                _isFloating = false;
            }
        }
    }
}
