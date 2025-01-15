using DG.Tweening;
using UnityEngine;
using Zenject;

public class EnemyMovement : MonoBehaviour
{
    [Inject]
    private EnemySpeed enemySpeed;

    private Tween tween;

    private void OnEnable()
    {
        Vector3 moveToPosition = transform.position;
        moveToPosition.z = -25f;

        tween.Kill();
        tween = transform.DOMove(moveToPosition, enemySpeed.speed)
            .SetSpeedBased().SetEase(Ease.Linear);
    }
}
