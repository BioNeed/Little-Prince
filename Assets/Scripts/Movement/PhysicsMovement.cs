using UnityEngine;

public class PhysicsMovement : MonoBehaviour
{
    [SerializeField] private SurfaceMovement _surfaceMovement;
    [SerializeField] private VerticalMovement _verticalMovement;
    
    private BranchPulling _branchPulling = null;
    private Rigidbody2D _rigidbody2D;
    private FloatingPlatform _floatingPlatform = null;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void SetBranchPulling(BranchPulling branchPulling)
    {
        _branchPulling = branchPulling;
    }

    public void SetPlatformFloating(FloatingPlatform floatingPlatform)
    {
        _floatingPlatform = floatingPlatform;
    }

    public void Move(Vector2 direction)
    {
        Vector2 movePosition = Vector2.zero;

        if (_branchPulling != null && _branchPulling.IsPulling == true)
        {
            movePosition += _branchPulling.CalculatePullingMovement();
        }
        else
        {
            if (_floatingPlatform != null)
            {
                movePosition += _floatingPlatform.FloatingMovement;
            }

            movePosition += _surfaceMovement.CalculateSurfaceMovement(direction);
            movePosition += _verticalMovement.CalculateVerticalMovement();
        }

        _rigidbody2D.MovePosition(transform.position + new Vector3(movePosition.x, movePosition.y, 0));
    }
}