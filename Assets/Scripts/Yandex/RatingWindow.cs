using UnityEngine;
using YG;

public class RatingWindow : MonoBehaviour
{
    private void Awake()
    {
        if (PlayerPrefs.HasKey("gameCount") && YandexGame.SDKEnabled)
            YandexGame.ReviewShow(true);
        else
            PlayerPrefs.SetInt("gameCount", 1);
    }
}
