using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _gravityScale;

    private float _verticalMovePosition;
    private bool _isJumped = false;

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

        return new Vector2(0, _verticalMovePosition * Time.fixedDeltaTime);
    }

    public void Jump()
    {
        if (_groundChecker.IsGrounded == true && _isJumped == false)
        {
            _isJumped = true;
        }
    }
}
