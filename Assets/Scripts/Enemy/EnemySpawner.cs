using System.Collections;
using UnityEngine;
using Zenject;
using Random = System.Random;

public class EnemySpawner : MonoBehaviour
{
    [Inject]
    private ObjectPooler objectPooler;

    [SerializeField]
    private Transform[] enemyPositions;

    [SerializeField]
    private float spawnTime;

    private int currentSpawnLine, lastSpawnLine;

    private Random random = new Random();

    private void Start() => StartCoroutine(EnemySpawnCoroutine());

    private IEnumerator EnemySpawnCoroutine()
    {
        yield return new WaitForSeconds(1f);

        while (true)
        {
            while (currentSpawnLine == lastSpawnLine)
                currentSpawnLine = random.Next(0, 3);

            lastSpawnLine = currentSpawnLine;

            SpawnEnemy("enemy", enemyPositions[currentSpawnLine].position);

            yield return new WaitForSeconds(spawnTime);
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

    public float GetSpawnTime() => spawnTime;

    public void SetSpawnTime(float time) => spawnTime = time;
}
