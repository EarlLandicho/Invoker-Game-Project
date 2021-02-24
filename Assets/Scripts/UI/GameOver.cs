using UnityEngine;

public class GameOver : MonoBehaviour
{
    private GameObject gameOverScreen;

    private void Awake()
    {
        GameObject.FindObjectOfType<PlayerHealth>().IsDead += EndGame;
        gameOverScreen = GameObject.Find("GameOverScreen");
        gameOverScreen.SetActive(false);
    }

    private void EndGame()
    {
        GameOverScreen();
        StopGame();
    }

    private void GameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }

    private void StopGame()
    {
        Time.timeScale = 0;
    }

    private void OnDestroy()
    {
        Time.timeScale = 1;
    }
}