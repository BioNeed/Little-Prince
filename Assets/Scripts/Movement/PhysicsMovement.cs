using UnityEngine;

public class PhysicsMovement : MonoBehaviour
{
    [SerializeField] private SurfaceMovement _surfaceMovement;
    [SerializeField] private VerticalMovement _verticalMovement;
    
    private BranchPulling _branchPulling = null;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void SetBranchPulling(BranchPulling branchPulling)
    {
        _branchPulling = branchPulling;
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
            movePosition += _surfaceMovement.CalculateSurfaceMovement(direction);
            movePosition += _verticalMovement.CalculateVerticalMovement();
        }

        _rigidbody2D.MovePosition(_rigidbody2D.position + movePosition);
    }
}
