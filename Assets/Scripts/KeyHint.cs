using UnityEngine;

public class KeyHint : MonoBehaviour
{
    [SerializeField] private GameObject _hint;

    private void Start()
    {
        _hint.SetActive(false);
    }

    public void ToggleHint(bool show)
    {
        if (show)
        {
            _hint.SetActive(true);
        }
        else
        {
            _hint.SetActive(false);
        }
    }
}
