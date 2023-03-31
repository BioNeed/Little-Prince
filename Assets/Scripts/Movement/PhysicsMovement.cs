using UnityEngine;

public class PhysicsMovement : MonoBehaviour
{
    [SerializeField] private SurfaceMovement _surfaceMovement;
    [SerializeField] private VerticalMovement _verticalMovement;

    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 direction)
    {
        Vector2 surfaceMovePosition = _surfaceMovement.CalculateSurfaceMovement(direction);

        Vector2 verticalMovePosition = _verticalMovement.CalculateVerticalMovement();

        Vector2 movePosition = surfaceMovePosition + verticalMovePosition;
        _rigidbody2D.MovePosition(_rigidbody2D.position + movePosition);
    }
}
