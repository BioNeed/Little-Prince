using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class GroundChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayerMask;

    private readonly List<Collider2D> _groundColliders = new List<Collider2D>();
    private bool _isGrounded = false;
    private int _currentCollisionCount = 0;

    public const float GroundDistance = 0.0094f;

    public bool IsGrounded => _isGrounded;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (MaskContainsLayer(collision.gameObject.layer))
        {
            Vector3 collisionPoint = collision.ClosestPoint(transform.position);

            if (collisionPoint.y - collision.bounds.max.y >= GroundDistance)
            {
                _currentCollisionCount++;
                _isGrounded = true;
                _groundColliders.Add(collision);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_groundColliders.Contains(collision))
        {
            _currentCollisionCount--;
            _groundColliders.Remove(collision);

            if (_currentCollisionCount == 0)
            {
                _isGrounded = false;
            }
        }
    }

    private bool MaskContainsLayer(int layerNumber)
    {
        if (_groundLayerMask == (_groundLayerMask | (1 << layerNumber)))
        {
            return true;
        }

        return false;
    }
}