using TMPro;
using UnityEngine;

public class ScoreSpawner : SpawnParentScript
{
    public void ShowScore(string tag, string text)
    {
        if (objectPooler.poolDictionary.ContainsKey(tag))
        {
            GameObject obj = objectPooler.poolDictionary[tag].Dequeue();

            RectTransform rectTransform = obj.GetComponent<RectTransform>();
            int x = random.Next(-250, 250);
            int y = random.Next(-250, 100);
            rectTransform.anchoredPosition = new Vector2(x, y);

            TextMeshProUGUI textMeshProUGUI = obj.GetComponent<TextMeshProUGUI>();
            textMeshProUGUI.text = $"+{text}";

            obj.SetActive(true);
            objectPooler.poolDictionary[tag].Enqueue(obj);
        }
    }
}
