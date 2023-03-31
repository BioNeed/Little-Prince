using UnityEngine;

public class DirectionFlip : MonoBehaviour
{
    private bool _facingRight = true;

    public void TryFlip(float horizontalInput)
    {
        if (FacesRightDirection(horizontalInput) == false)
        {
            FlipScaleX();
        }
    }

    private bool FacesRightDirection(float horizontalInput)
    {
        if (_facingRight == true && horizontalInput > 0 ||
            _facingRight == false && horizontalInput < 0)
        {
            return true;
        }

        return false;
    }

    private void FlipScaleX()
    {
        float newScaleX = transform.localScale.x * (-1);
        transform.localScale = new Vector3(newScaleX, 1, 1);
        _facingRight = !_facingRight;
    }
}
