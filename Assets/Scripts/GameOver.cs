using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    
    private GameObject gameOverScreen;
    void Awake()
    {
        GameObject.FindObjectOfType<PlayerHealth>().IsDead += PlayerHasDied;
        gameOverScreen = GameObject.Find("GameOverScreen");
        gameOverScreen.SetActive(false);


    }
    private void PlayerHasDied()
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

    void OnDestroy()
    {
        Time.timeScale = 1;
    }


}
