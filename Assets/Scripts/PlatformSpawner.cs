using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject[] platformPrefabs;

    public Transform playerTransform;
    public float spawnDistance = 15f;
    public float minX = -2.5f, maxX = 2.5f;
    public float minYGap = 1.5f, maxYGap = 3.5f;

    private float lastSpawnY = 0f;

    void Update()
    {
        if (playerTransform != null && lastSpawnY < playerTransform.position.y + spawnDistance)
        {
            SpawnPlatform();
        }
    }

    public void SpawnPlatform()
    {
        lastSpawnY += Random.Range(minYGap, maxYGap);
        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPos = new Vector3(randomX, lastSpawnY, 0f);

        float chance = Random.Range(0f, 100f);
        int prefabIndex = 0;

        if (chance < 15f)
        {
            prefabIndex = 1;
        }
        else if (chance < 35f)
        {
            prefabIndex = 2;
        }
        else
        {
            prefabIndex = 0;
        }

        if (platformPrefabs.Length > prefabIndex)
        {
            Instantiate(platformPrefabs[prefabIndex], spawnPos, Quaternion.identity);
        }
    }
}