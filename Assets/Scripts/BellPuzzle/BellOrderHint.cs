using UnityEngine;

public class BellOrderHint : MonoBehaviour
{
    [SerializeField] private KeyHint _keyHint;
    [SerializeField] private BellPuzzle _bellPuzzle;

    private bool _active = false;

    private void Update()
    {
        if (_active && Input.GetKeyDown(KeyCode.E))
        {
            _bellPuzzle.RingAllOrdered();
        }
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
