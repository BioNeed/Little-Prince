using UnityEngine;

public class LeveragePuzzleCollision : MonoBehaviour
{
    [SerializeField] private CameraZooming _cameraZooming;
    [SerializeField] private float _cameraSizeOnZoom;
    [SerializeField] private Transform _cameraPositionOnZoom;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            _cameraZooming.ZoomCamera(_cameraPositionOnZoom.position, _cameraSizeOnZoom);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            _cameraZooming.UnZoomCamera();
        }
    }
}
