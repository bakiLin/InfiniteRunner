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
    private TextMeshProUGUI finishScore, finishHighscore, currentScore;

    [SerializeField]
    private RectTransform gameOverWindow;

    [SerializeField]
    private float enemyDistance;

    private int score;

    private void Awake()
    {
        if (YandexGame.auth)
        {
            finishHighscore.transform.parent.gameObject.SetActive(true);
            gameOverWindow.sizeDelta = new Vector2(gameOverWindow.sizeDelta.x, 400f);
        }
        else
        {
            finishHighscore.transform.parent.gameObject.SetActive(false);
            gameOverWindow.sizeDelta = new Vector2(gameOverWindow.sizeDelta.x, 300f);
        }

        enemySpawner.SetDelay(enemyDistance / enemySpeed.speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            score++;
            currentScore.text = score.ToString();

            enemySpawner.SetDelay(enemyDistance / enemySpeed.speed);

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

        currentScore.text = "";

        GetData();

        Destroy(gameObject);
    }

    private void OnEnable() => YandexGame.GetDataEvent += GetData;

    private void OnDisable() => YandexGame.GetDataEvent -= GetData;

    private async void GetData()
    {
        while (!YandexGame.SDKEnabled)
            await Task.Delay(200);

        if (YandexGame.EnvironmentData.language == "ru")
        {
            finishScore.text = $"—чЄт: {score}";
            finishHighscore.text = $"–екорд: {YandexGame.savesData.score}";
        }
        else
        {
            finishScore.text = $"Score: {score}";
            finishHighscore.text = $"Highscore: {YandexGame.savesData.score}";
        }
    }
}
