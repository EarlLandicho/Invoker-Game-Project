#region

using UnityEngine;

#endregion

[RequireComponent(typeof(SpriteRenderer))]
public class FlashWhenDamaged : MonoBehaviour
{
	private Color color;

	private void Awake()
	{
		color = Color.red;
	}

	//called by IHealth objects
	public void FlashSprite()
	{
		GetComponent<SpriteRenderer>().color = color;
		Invoke("ResetColor", Constants.flashDuration);
	}

	private void ResetColor()
	{
		GetComponent<SpriteRenderer>().color = Color.white;
	}
}