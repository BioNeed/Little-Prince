using UnityEngine;

public class LevelFinish : MonoBehaviour
{
    [SerializeField] private StarsCollectingProgress _starsCollectingProgress;
    [SerializeField] private GameProgress _gameProgress;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player _))
        {
            if (_starsCollectingProgress.AreStarsEnough())
            {
                _gameProgress.FinishLevel();
            }
            else
            {
                _gameProgress.FailLevel();
            }
        }
    }
}
