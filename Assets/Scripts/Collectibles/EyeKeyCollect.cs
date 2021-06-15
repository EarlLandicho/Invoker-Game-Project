using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeKeyCollect : MonoBehaviour
{
	[SerializeField] private AudioClip audioClip;
	public static int currentEyeKeyAmount;
	private AudioController audioController;

	private void Awake()
	{
		audioController = GameObject.Find("PickupAudio").GetComponent<AudioController>();
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			audioController.PlayClip(audioClip);
			currentEyeKeyAmount++;
			Destroy(gameObject);
		}
	}
	
	
}
