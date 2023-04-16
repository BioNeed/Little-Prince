using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayerMask;

    private bool _isGrounded = false;
    private const float GroundDistance = 0.3f;

    public bool IsGrounded => _isGrounded;

    private void Update()
    {
        Vector2 boxSize = new Vector2(1f, 0.4f);
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, boxSize, 0, Vector2.down, 1f, _groundLayerMask);

        _isGrounded = false;

        if (hit.collider != null)
        {
            float distanceToCollider = transform.position.y - hit.collider.ClosestPoint(transform.position).y;
           
            if (distanceToCollider < GroundDistance &&
                distanceToCollider > 0f)
            {
                _isGrounded = true;
            }
        }
    }
}
