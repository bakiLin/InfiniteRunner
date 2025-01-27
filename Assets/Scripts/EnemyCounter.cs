using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using YG;
using Zenject;

public class EnemyCounter : MonoBehaviour
{
    [Inject]
    private EnemySpawner enemySpawner;

    [Inject]
    private EnemySpeed enemySpeed;

    [SerializeField]
    private TextMeshProUGUI currentScore, bestScore, scoreText;

    [SerializeField]
    private RectTransform gameOverWindow;

    private int score;

    private void Awake()
    {
        if (YandexGame.auth)
        {
            bestScore.transform.parent.gameObject.SetActive(true);
            gameOverWindow.sizeDelta = new Vector2(gameOverWindow.sizeDelta.x, 400f);
        }
        else
        {
            bestScore.transform.parent.gameObject.SetActive(false);
            gameOverWindow.sizeDelta = new Vector2(gameOverWindow.sizeDelta.x, 300f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            score++;
            scoreText.text = score.ToString();

            if (enemySpawner.spawnDelay > 0.5f)
                enemySpawner.spawnDelay -= 0.02f;

            if (score > 100) enemySpeed.speed += 0.1f;
            else enemySpeed.speed += 0.3f;
        }
    }

    public void SetFinishResult()
    {
        if (YandexGame.auth)
        {
            if (score > YandexGame.savesData.score)
            {
                YandexGame.savesData.score = score;
                YandexGame.SaveProgress();
                YandexGame.NewLeaderboardScores("score", score);
            }
        }

        GetData();
    }

    private void OnEnable() => YandexGame.GetDataEvent += GetData;

    private void OnDisable() => YandexGame.GetDataEvent -= GetData;

    private async void GetData()
    {
        while (!YandexGame.SDKEnabled)
            await Task.Delay(200);

        if (YandexGame.EnvironmentData.language == "ru")
        {
            currentScore.text = $"—чЄт: {score}";
            bestScore.text = $"–екорд: {YandexGame.savesData.score}";
        }
        else
        {
            currentScore.text = $"Score: {score}";
            bestScore.text = $"Highscore: {YandexGame.savesData.score}";
        }
    }
}
