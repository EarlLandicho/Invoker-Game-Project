#region

using System;
using UnityEngine;

#endregion

public class TouchToEndGame : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.CompareTag("Player"))
		{
			EndGameByTouch();
		}
	}

	public static event Action EndGameByTouch = delegate { };
}