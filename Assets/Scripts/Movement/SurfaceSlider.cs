using UnityEngine;

public class SurfaceSlider : MonoBehaviour
{
    [SerializeField] private float _maxSurfaceIncline;

    private Vector2 _normal;

    public Vector2 Project(Vector2 forward)
    {
        return forward - Vector2.Dot(forward, _normal) * _normal;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Vector2.Angle(collision.contacts[0].normal, Vector2.up) < 90)
            _normal = collision.contacts[0].normal;
    }

    private void OnCollisionExit2D()
    {
        _normal = Vector2.up;
    }
}
