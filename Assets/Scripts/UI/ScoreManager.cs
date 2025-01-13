using System.Collections;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    private Transform rectTransform;

    private Vector3 localPosition;

    private void OnEnable()
    {
        if (rectTransform == null)
            rectTransform = GetComponent<RectTransform>();
        else
            StartCoroutine(UpMovement());
    }

    private IEnumerator UpMovement()
    {
        while (true)
        {
            localPosition = rectTransform.localPosition;
            localPosition.y += Time.deltaTime * moveSpeed;
            rectTransform.localPosition = localPosition;
            yield return null;
        }
    }

    private void OnDisable() => StopAllCoroutines();

    public void DisableSelf() => gameObject.SetActive(false);
}
