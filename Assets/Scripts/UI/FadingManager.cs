using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadingManager : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup safeAreaCanvasGroup;

    [SerializeField]
    private Image fadeImage;

    private void Awake()
    {
        fadeImage.DOFade(0f, 2f).OnComplete(() => {
            safeAreaCanvasGroup.interactable = true;
        });
    }

    public void LoadLevel(int sceneIndex)
    {
        safeAreaCanvasGroup.interactable = false;

        fadeImage.DOFade(1f, 1.5f)
            .SetUpdate(true)
            .OnComplete(() => {
                SceneManager.LoadScene(sceneIndex);
                Time.timeScale = 1f;
            });
    }
}
