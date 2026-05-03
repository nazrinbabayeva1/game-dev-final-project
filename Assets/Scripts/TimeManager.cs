using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;

    [Header("Time")]
    public float currentTime = 30f;
    public float startTime = 30f;

    [Header("UI")]
    public TextMeshProUGUI timeText;
    public GameObject gameOverText;

    [Header("Player")]
    public Transform player;
    public Transform startPoint;
    private Rigidbody playerRb;

    [Header("Game State")]
    private bool isGameOver = false;

    [Header("Enemy System")]
    public EnemySpawner enemySpawner; // assign in inspector

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        playerRb = player.GetComponent<Rigidbody>();
        gameOverText.SetActive(false);
    }

    void Update()
    {
        if (isGameOver) return;

        // decrease time
        currentTime -= Time.deltaTime;

        // clamp (NEVER negative)
        currentTime = Mathf.Max(0, currentTime);

        // UI update
        timeText.text = "Time: " + Mathf.Ceil(currentTime);

        // game over check
        if (currentTime <= 0)
        {
            GameOver();
        }

        // low time warning (optional polish)
        if (currentTime < 10)
        {
            timeText.color = Color.red;
        }
        else
        {
            timeText.color = new Color(1f, 0.4f, 0.7f);
        }
    }

    // 🔵 + 🔴 crystal system
    public void AddTime(float amount)
    {
        if (isGameOver) return;

        currentTime = Mathf.Max(0, currentTime + amount);
    }

    // 🔵 called ONLY by blue crystal
    public void OnBlueCrystalCollected()
    {
        if (isGameOver) return;

        AddTime(3f);

        // spawn enemy each time blue crystal is collected
        if (enemySpawner != null)
        {
            enemySpawner.SpawnOneEnemy();
        }
    }

    void GameOver()
    {
        isGameOver = true;

        gameOverText.SetActive(true);

        // stop player movement
        if (playerRb != null)
        {
            playerRb.velocity = Vector3.zero;
        }

        Invoke("ResetGame", 2f);
    }

    void ResetGame()
    {
        // reset player position
        player.position = startPoint.position;

        if (playerRb != null)
        {
            playerRb.velocity = Vector3.zero;
        }

        // reset time
        currentTime = startTime;

        // reset UI
        gameOverText.SetActive(false);
        timeText.color = Color.white;

        isGameOver = false;
    }
}