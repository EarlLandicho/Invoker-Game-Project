#region

using UnityEngine;

#endregion

public class GameOver : MonoBehaviour
{
	private bool gameIsOver;
	private GameObject gameOverScreen;
	private AudioSource gameOverAudioSource;
	private AudioSource backgroundMusicAudioSource;
	private PlayerHealth playerHealth;
	

	private void Awake()
	{
		playerHealth = FindObjectOfType<PlayerHealth>();
		playerHealth.IsDead += EndGame;
		TouchToEndGame.EndGameByTouch += EndGame;
		gameOverScreen = GameObject.Find("GameOverScreen");
		gameOverScreen.SetActive(false);
		gameOverAudioSource = GameObject.Find("GameOverAudio").GetComponent<AudioSource>();
		backgroundMusicAudioSource = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();
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
		playerHealth.IsDead -= EndGame;
		TouchToEndGame.EndGameByTouch -= EndGame;
	}

	private void EndGame()
	{
		gameIsOver = true;
		GameOverScreen();
	}

	private void GameOverScreen()
	{
		gameOverAudioSource.Play();
		gameOverScreen.SetActive(true);
	}

	private void StopGame()
	{
		Time.timeScale = 0;
		backgroundMusicAudioSource.Stop();
	}
}