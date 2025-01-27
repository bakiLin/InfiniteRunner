using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using YG;
using Zenject;

public class ButtonManager : MonoBehaviour
{
    [Inject]
    private FadingManager fadingManager;

    [Inject]
    private IconsManager iconsManager;

    [SerializeField]
    private Image pauseButtonImage, audioButtonImage;

    [SerializeField]
    private CanvasGroup gameOver;

    [SerializeField]
    private GameObject pauseWindow;

    private AudioManager audioManager;

    private bool paused;

    private void Awake()
    {
        audioManager = GameObject.FindFirstObjectByType<AudioManager>();

        if (PlayerPrefs.GetInt("soundOn") == 0)
            audioButtonImage.sprite = iconsManager.soundOn;
        else if (!YandexGame.nowFullAd)
            audioManager.PlayTheme(true);
    }

    public void PauseButton()
    {
        if (!paused)
        {
            Time.timeScale = 0f;
            pauseWindow.SetActive(true);
            pauseButtonImage.sprite = iconsManager.play;
            audioManager.FadeTheme(0.1f, 0.1f);
        }
        else
        {
            Time.timeScale = 1f;
            pauseWindow.SetActive(false);
            pauseButtonImage.sprite = iconsManager.pause;
            audioManager.FadeTheme(0.5f, 0.1f);
        }

        paused = !paused;
    }

    public void SoundButton()
    {
        if (PlayerPrefs.GetInt("soundOn") == 0)
        {
            audioManager.PlayTheme(true);
            audioButtonImage.sprite = iconsManager.soundOff;
        }
        else
        {
            audioManager.PlayTheme(false);
            audioButtonImage.sprite = iconsManager.soundOn;
        }
    }

    public void LoadLevel(int sceneIndex)
    {
        fadingManager.LoadLevel(sceneIndex);
        audioManager.FadeTheme(0f, 1f);
    }

    public void GameOver()
    {
        pauseButtonImage.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(true);
        gameOver.DOFade(1f, 1f);
    }
}