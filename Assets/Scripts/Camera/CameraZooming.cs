using UnityEngine;

public class CameraZooming : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private CameraFollow _cameraFollow;

    private float _initialSize;
    
    public void ZoomCamera(Vector2 newPosition, float newSize)
    {
        var cameraPosition = new Vector3
        {
            x = newPosition.x,
            y = newPosition.y,
            z = transform.position.z,
        };

        transform.position = cameraPosition;
        _camera.orthographicSize = newSize;
        _cameraFollow.enabled = false;
    }

    public void UnZoomCamera()
    {
        _camera.orthographicSize = _initialSize; 
        _cameraFollow.enabled = true;
    }

    private void Start()
    {
        _initialSize = _camera.orthographicSize;
    }
}
