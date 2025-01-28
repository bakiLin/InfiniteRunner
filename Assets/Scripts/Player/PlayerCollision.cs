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
    private ButtonManager buttonManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            playerInputScript.enabled = false;
            particleManager.ParticlePlay();
            renderTrail.MoveTrail();

            enemyCounter.SetFinishResult();

            spawnManager.StopAllCoroutines();
            buttonManager.GameOver();

            gameObject.SetActive(false);
        }
    }
}
