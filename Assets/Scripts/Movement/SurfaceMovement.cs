using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SurfaceMovement : MonoBehaviour
{
    [SerializeField] private SurfaceSlider _surfaceSlider;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _speed;

    public Vector2 CalculateSurfaceMovement(Vector2 direction)
    {
        Vector2 directionAlongSurface = _surfaceSlider.Project(direction);
        Vector2 movePosition = directionAlongSurface * _speed;

        _animator.SetFloat("Speed", Mathf.Abs(movePosition.x));
        return movePosition * Time.fixedDeltaTime;
    }
}