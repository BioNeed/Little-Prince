using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayerMask;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _gravityScale;
    [SerializeField] private MovementSounds _movementSounds;

    private const float EpsilonDistance = 0.01f;

    private float _verticalMovePosition;
    private bool _isJumped = false;
    private BoxCollider2D _collider;

    private void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
    }

    public Vector2 CalculateVerticalMovement()
    {
        if (_groundChecker.IsGrounded == true)
        {
            _verticalMovePosition = 0f;
        }
        else
        {
            _verticalMovePosition += Physics2D.gravity.y * _gravityScale;
        }

        if (_isJumped == true)
        {
            _verticalMovePosition += _jumpForce;
            _isJumped = false;
        }

        var calculatedMovePosition = new Vector2(
            0,
            _verticalMovePosition * Time.fixedDeltaTime);

        var finalVerticalMovePosition = CalculateMovementToObstacle(calculatedMovePosition);

        return finalVerticalMovePosition;
    }

    public void Jump()
    {
        if (_groundChecker.IsGrounded == true && _isJumped == false)
        {
            _isJumped = true;
            _movementSounds.PlayJumpSound();
        }
    }

    public void StopJump()
    {
        _verticalMovePosition = 0f;
    }

    private Vector2 CalculateMovementToObstacle(Vector2 verticalMovePosition)
    {
        var boxSize = new Vector2(_collider.size.x, _collider.size.y / 2 + 1f);

        var hit = Physics2D.BoxCast(
            transform.position,
            boxSize, 
            0,
            verticalMovePosition, 
            verticalMovePosition.magnitude, 
            _groundLayerMask);

        if (hit.collider == null || hit.collider.usedByEffector)
        {
            return verticalMovePosition;
        }

        var objectClosestPoint = hit.collider.ClosestPoint(transform.position);
        var moveToCollider = objectClosestPoint.y - _collider.ClosestPoint(objectClosestPoint).y;

        if (moveToCollider > verticalMovePosition.magnitude
            || Mathf.Sign(moveToCollider) != Mathf.Sign(verticalMovePosition.y))
        {
            return verticalMovePosition;
        }

        if (moveToCollider > EpsilonDistance)
        {
            _verticalMovePosition = moveToCollider;

            return new Vector2
            {
                x = 0,
                y = _verticalMovePosition,
            };
        }

        return verticalMovePosition;
    }
}
