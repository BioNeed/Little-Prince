using UnityEngine;

public class LevelFinish : MonoBehaviour
{
    [SerializeField] private GameProgress _gameProgress;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player _))
        {
            _gameProgress.FinishLevel();
        }
    }
}
