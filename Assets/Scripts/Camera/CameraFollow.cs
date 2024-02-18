using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private Vector2 _offset;

    private void LateUpdate()
    {
        transform.position = new Vector3(_target.transform.position.x + _offset.x,
            _target.transform.position.y + _offset.y,
            transform.position.z);
    }
}
