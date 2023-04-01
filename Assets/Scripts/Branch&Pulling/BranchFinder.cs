using UnityEngine;

public class BranchFinder : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private PhysicsMovement _physicsMovement;
    [SerializeField] private VerticalMovement _verticalMovement;

    public void FindBranchToPull()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D[] hits = Physics2D.RaycastAll(mousePosition, mousePosition);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider.TryGetComponent(out BranchPulling branchPulling))
            {
                branchPulling.TryStartPulling(_target);
                _verticalMovement.StopJump();
                _physicsMovement.SetBranchPulling(branchPulling);
                break;
            }
        }
    }
}
