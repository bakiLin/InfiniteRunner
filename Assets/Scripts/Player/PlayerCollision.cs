using UnityEngine;
using Zenject;

public class PlayerCollision : MonoBehaviour
{
    [Inject]
    private PlayerInputScript playerInputScript;

    [Inject]
    private PassedEnemyCounter passedEnemyCounter;

    [Inject]
    private EnemySpawner spawnManager;

    [Inject]
    private ParticleManager particleManager;

    [Inject]
    private RenderTrail renderTrail;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            particleManager.ParticleBehaviour();
            playerInputScript.StopInput();
            passedEnemyCounter.StopCount();
            spawnManager.StopSpawn();
            renderTrail.TrailBehaviour();
            gameObject.SetActive(false);
        }
    }
}
