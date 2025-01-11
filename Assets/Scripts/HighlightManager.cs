using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighlightManager : MonoBehaviour
{
    public void Highlight(Button button)
    {
        Color buttonColor = button.GetComponent<Image>().color;
        
        TextMeshProUGUI text = button.GetComponentInChildren<TextMeshProUGUI>();

        text.color = buttonColor;
        buttonColor.a = 0f;

        button.GetComponent<Image>().color = buttonColor;
    }
}
