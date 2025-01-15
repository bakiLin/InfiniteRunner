using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ButtonManager : MonoBehaviour
{
    [Inject]
    private FadingManager fadingManager;

    [Inject]
    private IconsManager iconsManager;

    [Inject]
    private AudioManager audioManager;

    [SerializeField]
    private Button pauseButton;

    [SerializeField]
    private GameObject pauseWindow;

    [SerializeField]
    private CanvasGroup gameOverCanvasGroup;

    private bool paused;

    public void Pause()
    {
        if (!paused)
        {
            Time.timeScale = 0f;
            pauseWindow.SetActive(true);
            pauseButton.GetComponent<Image>().sprite = iconsManager.play;
            audioManager.PauseSound("Theme", false);
        }
        else
        {
            Time.timeScale = 1f;
            pauseWindow.SetActive(false);
            pauseButton.GetComponent<Image>().sprite = iconsManager.pause;
            audioManager.PauseSound("Theme", true);
        }

        paused = !paused;
    }

    public void SoundButton(Button button)
    {
        Image buttonImage = button.GetComponent<Image>(); 

        if (buttonImage.sprite.Equals(iconsManager.soundOn))
        {
            audioManager.PlaySound("Theme");
            button.GetComponent<Image>().sprite = iconsManager.soundOff;
        }
        else
        {
            audioManager.StopSound("Theme");
            button.GetComponent<Image>().sprite = iconsManager.soundOn;
        }
    }

    public void LoadLevel(int sceneIndex)
    {
        fadingManager.LoadLevel(sceneIndex);
        audioManager.FadeSoundToZero("Theme");
    }

    public void GameOver()
    {
        pauseButton.gameObject.SetActive(false);

        gameOverCanvasGroup.gameObject.SetActive(true);
        gameOverCanvasGroup.DOFade(1f, 1f);
    }
}