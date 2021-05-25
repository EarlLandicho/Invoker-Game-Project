#region

using System;
using UnityEngine;

#endregion

public class TouchToEndGame : MonoBehaviour
{
	[SerializeField] private int keyNeeded;

	
	public static event Action EndGameByTouch = delegate { };

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.CompareTag("Player") && EyeKeyCollect.currentEyeKeyAmount >= keyNeeded)
		{
			EndGameByTouch();
			EyeKeyCollect.currentEyeKeyAmount = 0;
		}
	}
}