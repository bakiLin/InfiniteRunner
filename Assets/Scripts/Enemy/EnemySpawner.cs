using System.Collections;
using UnityEngine;

public class EnemySpawner : SpawnParentScript
{
    [SerializeField]
    private Transform[] enemyPositions;

    public float spawnDelay;

    private int currentSpawnLine, lastSpawnLine;

    private void Awake()
    {
        StartCoroutine(EnemySpawnCoroutine());
    }

    private IEnumerator EnemySpawnCoroutine()
    {
        yield return new WaitForSeconds(1f);

        while (true)
        {
            while (currentSpawnLine == lastSpawnLine)
                currentSpawnLine = random.Next(0, 3);

            lastSpawnLine = currentSpawnLine;

            SpawnEnemy("enemy", enemyPositions[currentSpawnLine].position);

            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private void SpawnEnemy(string tag, Vector3 position)
    {
        if (objectPooler.poolDictionary.ContainsKey(tag))
        {
            GameObject obj = objectPooler.poolDictionary[tag].Dequeue();
            obj.SetActive(false);
            obj.transform.position = position;
            obj.SetActive(true);
            objectPooler.poolDictionary[tag].Enqueue(obj);
        }
    }

    public void StopSpawn() => StopAllCoroutines();
}
