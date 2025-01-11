using UnityEngine;
using Zenject;

public class Installer : MonoInstaller
{
    [SerializeField]
    private ObjectPooler objectPooler;

    [SerializeField]
    private PassedEnemyCounter passedEnemyCounter;

    [SerializeField]
    private EnemySpeed enemySpeed;

    [SerializeField]
    private EnemySpawner enemySpawner;

    [SerializeField]
    private PlayerInputScript playerInputScript;

    [SerializeField]
    private ScoreSpawner scoreSpawner;

    [SerializeField]
    private ParticleManager particleManager;

    [SerializeField]
    private RenderTrail renderTrail;

    public override void InstallBindings()
    {
        Container.Bind<ObjectPooler>().FromInstance(objectPooler).AsSingle().NonLazy();

        Container.Bind<PassedEnemyCounter>().FromInstance(passedEnemyCounter).AsSingle().NonLazy();

        Container.Bind<EnemySpeed>().FromInstance(enemySpeed).AsSingle().NonLazy();

        Container.Bind<EnemySpawner>().FromInstance(enemySpawner).AsSingle().NonLazy();

        Container.Bind<PlayerInputScript>().FromInstance(playerInputScript).AsSingle().NonLazy();

        Container.Bind<ScoreSpawner>().FromInstance(scoreSpawner).AsSingle().NonLazy();

        Container.Bind<ParticleManager>().FromInstance(particleManager).AsSingle().NonLazy();

        Container.Bind<RenderTrail>().FromInstance(renderTrail).AsSingle().NonLazy();
    }
}
