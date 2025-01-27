using UnityEngine;
using UnityEngine.UI;

public class ClickManager : MonoBehaviour
{
    [SerializeField]
    private Button[] buttons;

    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindFirstObjectByType<AudioManager>();

        foreach (var button in buttons)
        {
            button.onClick.AddListener(
                delegate { 
                    audioManager.ClickSound(); 
                });
        }
    }
}
