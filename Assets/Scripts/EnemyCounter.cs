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

    [Inject]
    private ScoreSpawner scoreSpawner;

    [SerializeField]
    private TextMeshProUGUI currentScoreText, bestScoreText;

    private int score;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            score++;

            if (enemySpawner.spawnDelay > 0.4f)
                enemySpawner.spawnDelay -= 0.02f;

            if (score > 100) enemySpeed.speed += 0.1f;
            else enemySpeed.speed += 0.3f;

            scoreSpawner.ShowScore("score", score.ToString());
        }
    }

    public void SetFinishResult()
    {
        if (score > YandexGame.savesData.score)
        {
            YandexGame.savesData.score = score;
            YandexGame.NewLeaderboardScores("score", score);
        }

        GetData();
    }

    private void OnEnable()
    {
        YandexGame.GetDataEvent += GetData;
    }

    private void OnDisable()
    {
        YandexGame.GetDataEvent -= GetData;
    }

    private async void GetData()
    {
        while (!YandexGame.SDKEnabled)
            await Task.Delay(200);

        if (YandexGame.EnvironmentData.language == "ru")
        {
            currentScoreText.text = $"—чЄт: {score}";
            bestScoreText.text = $"–екорд: {YandexGame.savesData.score}";
        }
        else
        {
            currentScoreText.text = $"Score: {score}";
            bestScoreText.text = $"Highscore: {YandexGame.savesData.score}";
        }
    }


}
