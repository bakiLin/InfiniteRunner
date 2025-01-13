using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameButtonManager : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup canvasGroup;

    [SerializeField]
    private Image fadeImage;

    [SerializeField]
    private GameObject pauseWindow;

    [SerializeField]
    private Sprite pauseIcon;

    [SerializeField]
    private Sprite playIcon;

    [SerializeField]
    private Sprite soundOnIcon;

    [SerializeField]
    private Sprite soundOffIcon;

    [SerializeField]
    private CanvasGroup gameOverCanvasGroup;

    [SerializeField]
    private GameObject pauseButton;

    private Tween tween;

    private bool paused;

    private void Awake() => StartCoroutine(GameStartCoroutine());

    private IEnumerator GameStartCoroutine()
    {
        tween.Kill();
        tween = fadeImage.DOFade(0f, 2f);

        yield return new WaitForSeconds(2f);

        canvasGroup.interactable = true;
    }

    public void Pause(Button button)
    {
        Image buttonImage = button.GetComponent<Image>();

        if (!paused)
        {
            Time.timeScale = 0f;
            pauseWindow.SetActive(true);
            buttonImage.sprite = playIcon;
        }
        else
        {
            Time.timeScale = 1f;
            pauseWindow.SetActive(false);
            buttonImage.sprite = pauseIcon;
        }

        paused = !paused;
    }

    public void BackToMenu() => StartCoroutine(LoadLevelCoroutine(0));

    public void RestartLevel() => StartCoroutine(LoadLevelCoroutine(1));

    public void SoundButton(Button button)
    {
        Image buttonImage = button.GetComponent<Image>();

        if (buttonImage.sprite == soundOnIcon)
            buttonImage.sprite = soundOffIcon;
        else
            buttonImage.sprite = soundOnIcon;
    }

    private IEnumerator LoadLevelCoroutine(int sceneIndex)
    {
        canvasGroup.interactable = false;

        tween.Kill();
        tween = fadeImage.DOFade(1f, 1.5f).SetUpdate(true);

        float time = 1.5f;

        while (time > 0f)
        {
            time -= Time.unscaledDeltaTime;
            yield return null;
        }

        SceneManager.LoadScene(sceneIndex);

        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        pauseButton.SetActive(false);

        gameOverCanvasGroup.gameObject.SetActive(true);
        gameOverCanvasGroup.interactable = true;

        tween.Kill();
        tween = gameOverCanvasGroup.DOFade(1f, 1f);
    }
}
