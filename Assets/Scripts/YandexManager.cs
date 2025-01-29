using System.Collections;
using TMPro;
using UnityEngine;
using YG;

public class YandexManager : MonoBehaviour
{
    [SerializeField]
    private LeaderboardYG leaderboardYG;

    [SerializeField]
    private TextMeshProUGUI[] username, score;

    [SerializeField]
    private RectTransform container;

    private void Start() => StartCoroutine(LoadDataCoroutine());

    private IEnumerator LoadDataCoroutine()
    {
        while (leaderboardYG.players.Length < 5)
            yield return null;

        for (int i = 0; i < 15; i++)
        {
            if (leaderboardYG.players.Length > i)
            { 
                username[i].text = leaderboardYG.players[i].data.name;
                score[i].text = leaderboardYG.players[i].data.score;
            }
            else
            {
                username[i].transform.parent.parent.gameObject.SetActive(false);

                Vector2 oldSize = container.rect.size;
                Vector2 deltaSize = new Vector2(oldSize.x, oldSize.y - 145f) - oldSize;

                container.offsetMin = container.offsetMin - new Vector2(deltaSize.x * container.pivot.x, deltaSize.y * container.pivot.y);
                container.offsetMax = container.offsetMax + new Vector2(deltaSize.x * (1f - container.pivot.x), deltaSize.y * (1f - container.pivot.y));
            }
        }
    }
}
