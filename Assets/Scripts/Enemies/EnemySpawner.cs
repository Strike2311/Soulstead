using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject[] enemyPrefabs;
    public float spawnInterval = 3f;
    public int maxEnemies = 10;

    private float timer;
    private int currentEnemyCount;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval && currentEnemyCount < maxEnemies)
        {
            SpawnEnemyAtScreenEdge();
            timer = 0f;
        }
    }

    void SpawnEnemyAtScreenEdge()
    {
        // Choose random edge: 0 = top, 1 = right, 2 = bottom, 3 = left
        int edge = Random.Range(0, 4);
        Vector2 spawnPosition = GetRandomPointOnEdge(edge);

        GameObject enemyToSpawn = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        GameObject enemy = Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity);
        currentEnemyCount++;

        // Track death
        EnemyBase baseEnemy = enemy.GetComponent<EnemyBase>();
        if (baseEnemy != null)
        {
            baseEnemy.OnDeath += HandleEnemyDeath;
        }
    }

    Vector2 GetRandomPointOnEdge(int edge)
    {
        float camHeight = 2f * mainCamera.orthographicSize;
        float camWidth = camHeight * mainCamera.aspect;

        Vector3 camCenter = mainCamera.transform.position;

        float left = camCenter.x - camWidth / 2f;
        float right = camCenter.x + camWidth / 2f;
        float top = camCenter.y + camHeight / 2f;
        float bottom = camCenter.y - camHeight / 2f;

        switch (edge)
        {
            case 0: // Top
                return new Vector2(Random.Range(left, right), top + 1f);
            case 1: // Right
                return new Vector2(right + 1f, Random.Range(bottom, top));
            case 2: // Bottom
                return new Vector2(Random.Range(left, right), bottom - 1f);
            case 3: // Left
                return new Vector2(left - 1f, Random.Range(bottom, top));
            default:
                return camCenter;
        }
    }

    void HandleEnemyDeath(int number)
    {
        currentEnemyCount--;
    }
}
