using UnityEngine;
using Zenject;

public class Installer : MonoInstaller
{
    [SerializeField]
    private ObjectPooler objectPooler;

    [SerializeField]
    private EnemyCounter enemyCounter;

    [SerializeField]
    private EnemySpeed enemySpeed;

    [SerializeField]
    private EnemySpawner enemySpawner;

    [SerializeField]
    private PlayerInputScript playerInputScript;

    [SerializeField]
    private ParticleManager particleManager;

    [SerializeField]
    private RenderTrail renderTrail;

    [SerializeField]
    private ButtonManager buttonManager;

    [SerializeField]
    private FadingManager fadingManager;

    [SerializeField]
    private IconsManager iconsManager;

    public override void InstallBindings()
    {
        Container.Bind<ObjectPooler>().FromInstance(objectPooler).AsSingle().NonLazy();

        Container.Bind<EnemyCounter>().FromInstance(enemyCounter).AsSingle().NonLazy();

        Container.Bind<EnemySpeed>().FromInstance(enemySpeed).AsSingle().NonLazy();

        Container.Bind<EnemySpawner>().FromInstance(enemySpawner).AsSingle().NonLazy();

        Container.Bind<PlayerInputScript>().FromInstance(playerInputScript).AsSingle().NonLazy();

        Container.Bind<ParticleManager>().FromInstance(particleManager).AsSingle().NonLazy();

        Container.Bind<RenderTrail>().FromInstance(renderTrail).AsSingle().NonLazy();

        Container.Bind<ButtonManager>().FromInstance(buttonManager).AsSingle().NonLazy();

        Container.Bind<FadingManager>().FromInstance(fadingManager).AsSingle().NonLazy();

        Container.Bind<IconsManager>().FromInstance(iconsManager).AsSingle().NonLazy();
    }
}
