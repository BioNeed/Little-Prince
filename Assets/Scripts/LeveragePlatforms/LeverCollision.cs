using UnityEngine;

public class LeverCollision : MonoBehaviour
{
    [SerializeField] private KeyHint _keyHint;
    [SerializeField] private Lever _lever;

    private bool _active = false;

    private void Update()
    {
        if (_active && Input.GetKeyDown(KeyCode.E))
        {
            ToggleLever();
        }
    }

    private void ToggleLever()
    {
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
