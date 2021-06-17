#region

using System;
using UnityEngine;

#endregion

public class TouchToEndGame : MonoBehaviour
{
	[SerializeField] private int keyNeeded;
	private AudioSource audioSource;

	public static event Action EndGameByTouch = delegate { };

	private void Awake()
	{
		audioSource = GameObject.Find("StageCompleteAudio").GetComponent<AudioSource>();

	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.CompareTag("Player") && EyeKeyCollect.currentEyeKeyAmount >= keyNeeded)
		{
			audioSource.Play();
			EndGameByTouch();
			EyeKeyCollect.currentEyeKeyAmount = 0;
		}
	}
}