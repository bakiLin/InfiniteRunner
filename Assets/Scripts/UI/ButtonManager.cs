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
    private Button pauseButton;

    [SerializeField]
    private Image audioButtonImage;

    [SerializeField]
    private GameObject pauseWindow;

    [SerializeField]
    private CanvasGroup gameOverCanvasGroup;

    private AudioManager audioManager;

    private bool paused;

    private void Awake()
    {
        audioManager = GameObject.FindFirstObjectByType<AudioManager>();

        if (PlayerPrefs.GetInt("soundOn") == 0)
            SetSoundIcon(true);
        else if (!YandexGame.nowFullAd)
            audioManager.TriggerSound("Theme", true);
    }

    public void Pause()
    {
        if (!paused)
        {
            Time.timeScale = 0f;
            pauseWindow.SetActive(true);
            pauseButton.GetComponent<Image>().sprite = iconsManager.play;
            audioManager.FadeSound("Theme", 0.1f, 0.1f);
        }
        else
        {
            Time.timeScale = 1f;
            pauseWindow.SetActive(false);
            pauseButton.GetComponent<Image>().sprite = iconsManager.pause;
            audioManager.FadeSound("Theme", 0.5f, 0.1f);
        }

        paused = !paused;
    }

    public void SoundButton()
    {
        if (PlayerPrefs.GetInt("soundOn") == 0)
        {
            audioManager.TriggerSound("Theme", true);
            SetSoundIcon(false);
        }
        else
        {
            audioManager.TriggerSound("Theme", false);
            SetSoundIcon(true);
        }
    }

    public void LoadLevel(int sceneIndex)
    {
        fadingManager.LoadLevel(sceneIndex);
        audioManager.FadeSound("Theme", 0f, 1f);
    }

    public void GameOver()
    {
        pauseButton.gameObject.SetActive(false);

        gameOverCanvasGroup.gameObject.SetActive(true);
        gameOverCanvasGroup.DOFade(1f, 1f);
    }

    public void SetSoundIcon(bool soundOn)
    {
        audioButtonImage.sprite = soundOn ? iconsManager.soundOn : iconsManager.soundOff;
    }
}