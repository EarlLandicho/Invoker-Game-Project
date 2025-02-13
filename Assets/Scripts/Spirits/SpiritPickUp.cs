﻿#region

using UnityEngine;

#endregion

public class SpiritPickUp : MonoBehaviour
{
	[SerializeField] private Spirits spirits;
	[SerializeField] private AudioClip audioClip;
	private SpiritArrayManager spiritArrayManager;
	private AudioController audioController;

	private void Awake()
	{
		spiritArrayManager = GameObject.Find("GameManager").GetComponent<SpiritArrayManager>();
		audioController = GameObject.Find("PickupAudio").GetComponent<AudioController>();
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.CompareTag("Player"))
		{
			if (spirits == Spirits.Spirit1)
			{
				spiritArrayManager.IncrementSpiritMaxAmount(1);
				spiritArrayManager.IncrementSpiritCurrentAmount(1);
			}
			else if (spirits == Spirits.Spirit2)
			{
				spiritArrayManager.IncrementSpiritMaxAmount(2);
				spiritArrayManager.IncrementSpiritCurrentAmount(2);
			}
			else if (spirits == Spirits.Spirit3)
			{
				spiritArrayManager.IncrementSpiritMaxAmount(3);
				spiritArrayManager.IncrementSpiritCurrentAmount(3);
			}
			
			audioController.PlayClip(audioClip);
			Destroy(gameObject);
		}
	}

	private enum Spirits
	{
		Spirit1,
		Spirit2,
		Spirit3
	}
}