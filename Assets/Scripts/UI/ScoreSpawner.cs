using TMPro;
using UnityEngine;
using Zenject;
using Random = System.Random;

public class ScoreSpawner : MonoBehaviour
{
    [Inject]
    private ObjectPooler objectPooler;

    private Random random = new Random();

    public void ShowScore(string tag, string text)
    {
        if (objectPooler.poolDictionary.ContainsKey(tag))
        {
            GameObject obj = objectPooler.poolDictionary[tag].Dequeue();

            RectTransform rectTransform = obj.GetComponent<RectTransform>();
            int x = random.Next(-800, 800);
            int y = random.Next(-900, 500);
            rectTransform.anchoredPosition = new Vector2(x, y);

            TextMeshProUGUI textMeshProUGUI = obj.GetComponent<TextMeshProUGUI>();
            textMeshProUGUI.text = $"+{text}";

            obj.SetActive(true);
            objectPooler.poolDictionary[tag].Enqueue(obj);
        }
    }
}
