using DG.Tweening;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed;

    [SerializeField]
    private Transform[] playerPositions;

    private int currentRow = 1;

    private Tween tween;

    public void MoveLeft()
    {
        if (currentRow != 0)
        {
            currentRow--;

            tween.Kill();
            tween = transform.DOMove(playerPositions[currentRow].position, playerSpeed)
                .SetSpeedBased()
                .SetEase(Ease.Linear);
        }
    }

    public void MoveRight()
    {
        if (currentRow != 2)
        {
            currentRow++;

            tween.Kill();
            tween = transform.DOMove(playerPositions[currentRow].position, playerSpeed)
                .SetSpeedBased()
                .SetEase(Ease.Linear);
        }
    }
}
