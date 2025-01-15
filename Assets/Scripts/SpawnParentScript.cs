using UnityEngine;
using Zenject;
using Random = System.Random;

public class SpawnParentScript : MonoBehaviour
{
    [Inject]
    protected ObjectPooler objectPooler;

    protected Random random = new Random();
}
