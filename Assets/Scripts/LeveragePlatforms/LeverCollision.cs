using UnityEngine;

public class LeverCollision : MonoBehaviour
{
    [SerializeField] private KeyHint _keyHint;
    [SerializeField] private Lever _lever;

    private bool _active = false;

    public bool IsLeverActive => _active;

    public void ToggleLever()
    {
        if (!_active)
        {
            return;
        }
        
        _lever.ToggleLever();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            _keyHint.ToggleHint(true);
            _active = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            _keyHint.ToggleHint(false);
            _active = false;
        }
    }
}
