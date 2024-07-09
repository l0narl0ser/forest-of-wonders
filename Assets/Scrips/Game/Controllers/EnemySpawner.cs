using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyController _enemy;

    private void Awake()
    {
        EnemyEvent.OnEnemySpawn += OnEnemySpawned;
    }

    private void OnEnemySpawned(Transform spawnPosition)
    {
        Instantiate(_enemy, spawnPosition.position, spawnPosition.rotation);
    }

    private void OnDestroy()
    {
        EnemyEvent.OnEnemySpawn -= OnEnemySpawned;
    }
}