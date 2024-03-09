using UnityEngine;

public class BellPlatform : MonoBehaviour
{
    [SerializeField] private Transform _destination;
    [SerializeField] private float _speed;

    private const float EpsilonDistance = 0.05f;

    private bool _isMoving = false;
    private bool _isDestinationReached = false;

    public void StartMovingPlatform()
    {
        _isMoving = true;
    }

    private void Update()
    {
        if (_isDestinationReached || !_isMoving)
        {
            return;
        }

        MoveToDestination();
    }

    private void MoveToDestination()
    {
        transform.position = Vector2.MoveTowards(
                    transform.position,
                    _destination.position,
                    _speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, _destination.position) < EpsilonDistance)
        {
            _isDestinationReached = true;
        }
    }
}
