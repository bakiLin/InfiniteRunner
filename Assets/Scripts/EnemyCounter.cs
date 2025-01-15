using TMPro;
using UnityEngine;
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
    private TextMeshProUGUI finalScore;

    private int score;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            score++;

            if (enemySpawner.spawnDelay > 0.45f)
                enemySpawner.spawnDelay -= 0.02f;

            if (score > 100) enemySpeed.speed += 0.1f;
            else enemySpeed.speed += 0.3f;

            scoreSpawner.ShowScore("score", score.ToString());
        }
    }

    public void SetFinishResult()
    {
        if (PlayerPrefs.HasKey("bestScore"))
        {
            if (PlayerPrefs.GetInt("bestScore") < score)
                PlayerPrefs.SetInt("bestScore", score);
        }
        else
            PlayerPrefs.SetInt("bestScore", score);

        string finalResult = $"Ðåêîðä: {PlayerPrefs.GetInt("bestScore")}\nÑ÷¸ò: {score}";
        finalScore.text = finalResult;
    }
}
