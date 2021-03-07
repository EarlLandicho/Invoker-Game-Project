using System;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private bool gameIsOver;
    private GameObject gameOverScreen;

    private void Awake()
    {
        FindObjectOfType<PlayerHealth>().IsDead += EndGame;
        TouchToEndGame.EndGameByTouch += EndGame;
        gameOverScreen = GameObject.Find("GameOverScreen");
        gameOverScreen.SetActive(false);
    }

    private void Update()
    {
        if (gameIsOver)
        {
            StopGame();
        }
    }

    private void EndGame()
    {
        gameIsOver = true;
        GameOverScreen();
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