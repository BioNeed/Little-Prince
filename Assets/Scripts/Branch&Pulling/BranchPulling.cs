using UnityEngine;

public class BranchPulling : MonoBehaviour
{
    [SerializeField] private float _pullingTime;
    [SerializeField] private MovementSounds _movementSounds;

    private const float EpsilonDistance = 0.2f;

    private bool _isPulling = false;
    private Vector2 _pullingVector;
    private Transform _pullingTarget;

    public bool IsPulling => _isPulling;

    public void TryStartPulling(Transform target)
    {
        if (_isPulling == true)
        {
            return;
        }

        _isPulling = true;

        _pullingVector = transform.position - target.transform.position;
        _pullingTarget = target;

        _movementSounds.PlayPullingSound();
    }

    public Vector2 CalculatePullingMovement()
    {
        if (Vector2.Distance(transform.position, _pullingTarget.position) > EpsilonDistance)
        {
            Vector2 pullingMovement = _pullingVector * Time.fixedDeltaTime / _pullingTime;
            return pullingMovement;
        }
        else
        {
            _isPulling = false;
            _movementSounds.StopPullingSound();

            return Vector2.zero;
        }
    }
}
