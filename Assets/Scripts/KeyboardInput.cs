using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    [SerializeField] private PhysicsMovement _physicsMovement;
    [SerializeField] private VerticalMovement _verticalMovement;
    [SerializeField] private DirectionFlip _directionFlip;
    [SerializeField] private BranchFinder _branchFinder;

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _verticalMovement.Jump();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            _branchFinder.FindBranchToPull();
        }
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0)
        {
            _directionFlip.TryFlip(horizontal);
        }

        _physicsMovement.Move(new Vector2(horizontal, 0));
    }
}