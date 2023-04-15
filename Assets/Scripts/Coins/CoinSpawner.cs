using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _coinsPrefabs;

    private CoinSpawnPoint[] _coinSpawnPoints;

    private void Start()
    {
        _coinSpawnPoints = GetComponentsInChildren<CoinSpawnPoint>();
        SpawnCoinsInPoints();
    }

    private void SpawnCoinsInPoints()
    {
        for (int i = 0; i < _coinSpawnPoints.Length; i++)
        {
            int randomPrefabIndex = Random.Range(0, _coinsPrefabs.Length);
            Instantiate(_coinsPrefabs[randomPrefabIndex], _coinSpawnPoints[i].transform, false);
        }
    }
}
