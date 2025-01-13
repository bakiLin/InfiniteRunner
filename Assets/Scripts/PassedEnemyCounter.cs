using UnityEngine;
using Zenject;

public class PassedEnemyCounter : MonoBehaviour
{
    [Inject]
    private EnemySpawner enemySpawner;

    [Inject]
    private EnemySpeed enemySpeed;

    [Inject]
    private ScoreSpawner scoreSpawner;

    private int score;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            score++;

            if (enemySpawner.GetSpawnTime() > 0.3f)
                enemySpawner.SetSpawnTime(enemySpawner.GetSpawnTime() - 0.02f);

            enemySpeed.SetNewSpeed(enemySpeed.GetSpeed() + 0.3f);

            scoreSpawner.ShowScore("score", score.ToString());
        }
    }

    public void StopCount() => Destroy(gameObject);
}
