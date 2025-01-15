using UnityEngine;
using DG.Tweening;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    private Transform rectTransform;

    private void Awake() => rectTransform = GetComponent<RectTransform>();

    private void OnEnable()
    {
        float movePositionY = rectTransform.position.y + 200f;
        rectTransform.DOMoveY(movePositionY, 1.5f)
            .OnComplete(() => { 
                gameObject.SetActive(false); 
            });
    }
}
