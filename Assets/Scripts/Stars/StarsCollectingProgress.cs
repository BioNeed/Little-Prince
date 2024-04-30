using UnityEngine;

public class StarsCollectingProgress : MonoBehaviour
{
    [SerializeField] private StarsDisplay _starsDisplay;
    [SerializeField] private int _starsToSucceed;

    private int _starsCollected = 0;

    private void Start()
    {
        DisplayStars();
    }

    public void CollectStar()
    {
        _starsCollected++;
        if (_starsCollected <= _starsToSucceed)
        {
            DisplayStars();
        }
    }

    public bool AreStarsEnough()
    {
        return _starsCollected >= _starsToSucceed;
    }

    private void DisplayStars()
    {
        _starsDisplay.DisplayStars(_starsCollected, _starsToSucceed);
    }
}