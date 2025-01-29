using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class LevelManager : MonoBehaviour
{
    public void LoadLevel(int index)
    {
        YandexGame.FullscreenShow();

        SceneManager.LoadScene(index);
    }
}
