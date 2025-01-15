using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField]
    private Sprite soundOn;

    [SerializeField]
    private Sprite soundOff;

    private void Awake()
    {
        PlayerPrefs.SetInt("soundOn", 1);
    }

    public void ManageSound(Button button)
    {
        Image buttonImage = button.GetComponent<Image>();

        if (buttonImage.sprite.Equals(soundOn))
            buttonImage.sprite = soundOff;
        else
            buttonImage.sprite = soundOn;
    }
}
