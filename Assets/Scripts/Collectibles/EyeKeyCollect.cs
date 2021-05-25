using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeKeyCollect : MonoBehaviour
{
	public static int currentEyeKeyAmount;

	public void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			currentEyeKeyAmount++;
			Destroy(gameObject);
		}
	}
	
	
}
