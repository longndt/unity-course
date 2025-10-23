using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Game Settings")]
    [SerializeField] private int targetScore = 10;
    [SerializeField] private float gameTime = 60f;

    [Header("UI References")]
    [SerializeField] private Text scoreText;
    [SerializeField] private Text timeText;
    [SerializeField] private Text gameOverText;

    // Note: In newer Unity versions, use TextMeshProUGUI instead of Text
    // [SerializeField] private TextMeshProUGUI scoreText;
    // [SerializeField] private TextMeshProUGUI timeText;
    // [SerializeField] private TextMeshProUGUI gameOverText;

    private int currentScore = 0;
    private float currentTime;
    private bool gameActive = true;

    void Start()
    {
        currentTime = gameTime;
        UpdateUI();
        Debug.Log("Game started! Target score: " + targetScore);
    }

    void Update()
    {
        if (gameActive)
        {
            // Update game timer
            currentTime -= Time.deltaTime;

            if (currentTime <= 0)
            {
                EndGame();
            }

            UpdateUI();
        }
    }

    public void AddScore(int points)
    {
        if (gameActive)
        {
            currentScore += points;
            Debug.Log("Score: " + currentScore);

            if (currentScore >= targetScore)
            {
                WinGame();
            }
        }
    }

    private void UpdateUI()
    {
        if (scoreText)
            scoreText.text = "Score: " + currentScore + " / " + targetScore;

        if (timeText)
            timeText.text = "Time: " + Mathf.Ceil(currentTime);
    }

    private void WinGame()
    {
        gameActive = false;
        if (gameOverText)
        {
            gameOverText.text = "You Win!";
            gameOverText.gameObject.SetActive(true);
        }
        Debug.Log("You Win! Final Score: " + currentScore);
    }

    private void EndGame()
    {
        gameActive = false;
        if (gameOverText)
        {
            gameOverText.text = "Game Over! Score: " + currentScore;
            gameOverText.gameObject.SetActive(true);
        }
        Debug.Log("Game Over! Final Score: " + currentScore);
    }

    public void RestartGame()
    {
        currentScore = 0;
        currentTime = gameTime;
        gameActive = true;

        if (gameOverText)
            gameOverText.gameObject.SetActive(false);

        Debug.Log("Game restarted!");
    }
}
