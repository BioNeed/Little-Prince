using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;

    private bool _isGrounded = false;
    private int _currentCollisionCount = 0;

    public bool IsGrounded => _isGrounded;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (MaskContainsLayer(collision.gameObject.layer))
        {
            _currentCollisionCount++;
            _isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (MaskContainsLayer(collision.gameObject.layer))
        {
            _currentCollisionCount--;

            if (_currentCollisionCount == 0)
            {
                _isGrounded = false;
            }
        }
    }

    private bool MaskContainsLayer(int layerNumber)
    {
        if (_layerMask == (_layerMask | (1 << layerNumber)))
        {
            return true;
        }

        return false;
    }
}