#region

using UnityEngine;

#endregion

public class GameOver : MonoBehaviour
{
	private bool gameIsOver;
	private GameObject gameOverScreen;
	private AudioSource audioSource;

	private void Awake()
	{
		FindObjectOfType<PlayerHealth>().IsDead += EndGame;
		TouchToEndGame.EndGameByTouch += EndGame;
		gameOverScreen = GameObject.Find("GameOverScreen");
		gameOverScreen.SetActive(false);
		audioSource = GameObject.Find("GameOverAudio").GetComponent<AudioSource>();
	}

	private void Update()
	{
		if (gameIsOver)
		{
			StopGame();
		}
	}

	private void OnDestroy()
	{
		Time.timeScale = 1;
	}

	private void EndGame()
	{
		gameIsOver = true;
		GameOverScreen();
	}

	private void GameOverScreen()
	{
		audioSource.Play();
		gameOverScreen.SetActive(true);
	}

	private void StopGame()
	{
		Time.timeScale = 0;
	}
}