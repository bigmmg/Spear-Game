using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button retryButton;
    public Button returnButton;
    public bool gameOver = false;

    public AudioClip gameOverSound;
    private int score = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = "Score: 0";
        gameOverText.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);
        returnButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addScore(int points)
    {
        if (gameOver) return;
        score += points;
        scoreText.text = "Score: " + score.ToString();
    }

    public void GameOver()
    {
        gameOver = true;
        Debug.Log("DONE!");

        gameOverText.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);
        returnButton.gameObject.SetActive(true);

        AudioSource.PlayClipAtPoint(gameOverSound, Camera.main.transform.position);

        Time.timeScale = 0f;
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainGame");
    }

    public void mainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
