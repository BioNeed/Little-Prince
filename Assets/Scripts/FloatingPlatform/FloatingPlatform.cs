using UnityEngine;

public class FloatingPlatform : MonoBehaviour
{
    [SerializeField] private WayPointsMovement _wayPointsMovement;
    [SerializeField] private float _speed;

    private const float EpsilonDistance = 0.05f;

    private WayPoint _nextWayPoint;
    private Vector2 _floatingMovementNormalized;

    public Vector2 FloatingMovement => _floatingMovementNormalized * _speed * Time.deltaTime;

    private void Start()
    {
        InitFloatingMovement();
    }

    private void Update()
    {
        transform.position = MoveTowards(_nextWayPoint.transform.position, _floatingMovementNormalized);

        if (Vector2.Distance(transform.position, _nextWayPoint.transform.position) < EpsilonDistance)
        {
            _floatingMovementNormalized = CalculateNewFloatingMovement();
        }
    }

    private void InitFloatingMovement()
    {
        WayPoint startWayPoint = _wayPointsMovement.NextWayPoint;
        transform.position = startWayPoint.transform.position;

        _floatingMovementNormalized = CalculateNewFloatingMovement();
    }

    private Vector2 CalculateNewFloatingMovement()
    {
        _nextWayPoint = _wayPointsMovement.FindNextWayPoint();

        Vector2 newFloatingMovement = _nextWayPoint.transform.position - transform.position;

        return newFloatingMovement.normalized;
    }

    private Vector2 MoveTowards(Vector3 towardsPosition, Vector2 movement)
    {
        Vector3 modifiedMovement = movement.normalized * _speed * Time.deltaTime;

        if (Vector2.Distance(transform.position, towardsPosition) < modifiedMovement.magnitude)
        {
            return towardsPosition;
        }

        return transform.position + modifiedMovement;
    }
}