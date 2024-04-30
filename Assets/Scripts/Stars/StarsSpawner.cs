using UnityEngine;

public class StarsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _starsPrefabs;

    private StarSpawnPoint[] _starSpawnPoints;

    private void Start()
    {
        _starSpawnPoints = GetComponentsInChildren<StarSpawnPoint>();
        SpawnStarsInPoints();
    }

    private void SpawnStarsInPoints()
    {
        for (int i = 0; i < _starSpawnPoints.Length; i++)
        {
            var randomPrefabIndex = Random.Range(0, _starsPrefabs.Length);
            Instantiate(_starsPrefabs[randomPrefabIndex], _starSpawnPoints[i].transform, false);
        }
    }
}
