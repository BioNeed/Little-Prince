using UnityEngine;

public class BranchFinder : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _playerRigidbody;

    public void FindBranchToPull()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D[] hits = Physics2D.RaycastAll(mousePosition, mousePosition);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider.TryGetComponent(out BranchPulling branchPulling))
            {
                branchPulling.Pull(_playerRigidbody);
                break;
            }
        }
    }
}
