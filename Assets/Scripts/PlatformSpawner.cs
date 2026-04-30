using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public float spawnDistance = 15f;
    public float minX = -2.5f, maxX = 2.5f;
    public float minYGap = 1.5f, maxYGap = 3.5f;

    private float lastSpawnY = 0f;
    public Transform playerTransform;

    void Update()
    {
        while (lastSpawnY < playerTransform.position.y + spawnDistance)
        {
            SpawnPlatform();
        }
    }

    public void SpawnPlatform()
    {
        lastSpawnY += Random.Range(minYGap, maxYGap);

        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPos = new Vector3(randomX, lastSpawnY, 0f);

        Instantiate(platformPrefab, spawnPos, Quaternion.identity);
    }
}