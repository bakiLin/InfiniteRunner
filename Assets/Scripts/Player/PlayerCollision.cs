using UnityEngine;
using Zenject;

public class PlayerCollision : MonoBehaviour
{
    [Inject]
    private PlayerInputScript playerInputScript;

    [Inject]
    private EnemyCounter enemyCounter;

    [Inject]
    private EnemySpawner spawnManager;

    [Inject]
    private ParticleManager particleManager;

    [Inject]
    private RenderTrail renderTrail;

    [Inject]
    private ButtonManager gameButtonManager;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            playerInputScript.enabled = false;
            particleManager.ParticlePlay();
            renderTrail.MoveTrail();

            enemyCounter.SetFinishResult();
            Destroy(enemyCounter.gameObject);

            enemyCounter.gameObject.SetActive(false);
            spawnManager.StopSpawn();
            gameButtonManager.GameOver();
            gameObject.SetActive(false);
        }
    }
}
