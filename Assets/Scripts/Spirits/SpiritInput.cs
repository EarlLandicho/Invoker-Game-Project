#region

using System;
using EasyFeedback;
using UnityEngine;

#endregion

public class SpiritInput : MonoBehaviour
{
	[SerializeField] private AudioClip spiritActivateAudioClip;
	private AudioSource audioSource;

	private void Awake()
	{
		audioSource = GetComponent<AudioSource>();
	}

	private void Update()
	{
		if (!FeedbackForm.formIsOpened)
		{
			InputCheck();
		}
	}

	public event Action InvokeSpiritsButtonPressed = delegate { };

	public event Action<int> SpiritsActivateButtonPressed = delegate { };

	public event Action ClearSpiritsButtonPressed = delegate { };

	//Used by animation spirit rotation
	public event Action UpdateSpiritAnimation = delegate { };

	private void InputCheck()
	{
		//SpiritsEnqueued event has 1, 2, 3 as inputs for spirit1, spirit2, spirit3 respectively
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			SpiritsActivateButtonPressed(1);
			audioSource.PlayOneShot(spiritActivateAudioClip);
			UpdateSpiritAnimation();
		}
		else if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			SpiritsActivateButtonPressed(2);
			audioSource.PlayOneShot(spiritActivateAudioClip);
			UpdateSpiritAnimation();
		}
		else if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			SpiritsActivateButtonPressed(3);
			audioSource.PlayOneShot(spiritActivateAudioClip);
			UpdateSpiritAnimation();
		}
		else if (Input.GetKeyDown(KeyCode.RightControl))
		{
			ClearSpiritsButtonPressed();
			UpdateSpiritAnimation();
		}
		else if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			InvokeSpiritsButtonPressed();
			UpdateSpiritAnimation();
		}
	}
}