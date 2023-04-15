using UnityEngine;

public class BranchFinder : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private PhysicsMovement _physicsMovement;
    [SerializeField] private VerticalMovement _verticalMovement;
    [SerializeField] private LayerMask _layerMask;

    public void FindBranchToPull()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, _layerMask);

        if (hit.collider != null && hit.collider.TryGetComponent(out BranchPulling branchPulling))
        {
            branchPulling.TryStartPulling(_target);
            _verticalMovement.StopJump();
            _physicsMovement.SetBranchPulling(branchPulling);
        }
    }
}
