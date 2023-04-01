using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class GroundChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayerMask;

    private const float GroundDistance = 0.0094f;

    private readonly List<Collider2D> _groundColliders = new();
    private Collider2D _checkerCollider;
    private bool _isGrounded = false;
    private int _currentCollisionCount = 0;

    private void Start()
    {
        _checkerCollider = GetComponent<Collider2D>();    
    }

    public bool IsGrounded => _isGrounded;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector3 collisionPoint = collision.ClosestPoint(transform.position);
        
        Vector2 collisionNormal = transform.position - collisionPoint;
        Debug.Log("_checkerCollider.bounds.max.y = " + _checkerCollider.bounds.max.y);
        Debug.Log("collision.bounds.max.y = " + collision.bounds.max.y);
        Debug.Log("collisionPoint.y - 0.01f = " + (collisionPoint.y - 0.01f));
        Debug.Log("collisionPoint.y - collision.bounds.max.y = " + (collisionPoint.y - collision.bounds.max.y));

        if (MaskContainsLayer(collision.gameObject.layer) &&
            collisionPoint.y - collision.bounds.max.y >= GroundDistance)
        {
            _currentCollisionCount++;
            _isGrounded = true;
            _groundColliders.Add(collision);
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