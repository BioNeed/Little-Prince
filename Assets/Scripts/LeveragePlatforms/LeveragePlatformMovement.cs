using UnityEngine;

namespace Assets.Scripts.LeveragePlatforms
{
    public class LeveragePlatformMovement : MonoBehaviour
    {
        [SerializeField] private LeveragePlatformPositions _leveragePlatformPositions;
        [SerializeField] private float _speed;
        [SerializeField] private int _initialLevel;

        private const float EpsilonDistance = 0.05f;

        private bool _reachedPosition;
        private int _currentLevel;
        private Vector2 _movementNormalized;
        private Vector2 _nextPosition;

        public void MovePlatform(bool up)
        {
            if (up)
            {
                _currentLevel++;
            }
            else
            {
                _currentLevel--;
            }

            InitiateMovement();
        }

        private void Start()
        {
            _currentLevel = _initialLevel;
            SetInitialPosition();
            _reachedPosition = true;
        }

        private void Update()
        {
            if (_reachedPosition)
            {
                return;
            }

            transform.position = MoveTowards(_nextPosition, _movementNormalized);

            if (Vector2.Distance(transform.position, _nextPosition) < EpsilonDistance)
            {
                StopMovement();
            }
        }

        private void StopMovement()
        {
            var reachedPosition = new Vector3
            {
                x = _nextPosition.x,
                y = _nextPosition.y,
                z = transform.position.z,
            };

            transform.position = reachedPosition;
            _reachedPosition = true;
        }

        private Vector2 MoveTowards(Vector2 towardsPosition, Vector2 movement)
        {
            Vector3 modifiedMovement = movement.normalized * _speed * Time.deltaTime;

            if (Vector2.Distance(transform.position, towardsPosition) < modifiedMovement.magnitude)
            {
                return towardsPosition;
            }

            return transform.position + modifiedMovement;
        }

        private void InitiateMovement()
        {
            _nextPosition = new Vector3
            {
                x = transform.position.x,
                y = _leveragePlatformPositions.GetLevelHeight(_currentLevel),
                z = transform.position.z,
            };

            _reachedPosition = false;
            _movementNormalized = CalculatePlatformMovement();
        }

        private void SetInitialPosition()
        {
            var newPlatformPosition = new Vector3
            {
                x = transform.position.x,
                y = _leveragePlatformPositions.GetLevelHeight(_initialLevel),
                z = transform.position.z,
            };

            transform.position = newPlatformPosition;
        }

        private Vector2 CalculatePlatformMovement()
        {
            var newFloatingMovement = new Vector2
            {
                x = _nextPosition.x - transform.position.x,
                y = _nextPosition.y - transform.position.y,
            };

            return newFloatingMovement.normalized;
        }
    }
}
