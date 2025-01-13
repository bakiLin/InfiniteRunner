using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuButtonManager : MonoBehaviour
{
    [SerializeField]
    private Image fadeImage;

    private Tween tween;

    private CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void ButtonPress(int sceneIndex) => StartCoroutine(ButtonPressCoroutine(sceneIndex));

    private IEnumerator ButtonPressCoroutine(int sceneIndex)
    {
        canvasGroup.interactable = false;

        tween.Kill();
        tween = fadeImage.DOFade(1f, 1f);

        yield return new WaitForSeconds(1f);

        if (sceneIndex != SceneManager.GetActiveScene().buildIndex)
            SceneManager.LoadScene(sceneIndex);
    }
}
