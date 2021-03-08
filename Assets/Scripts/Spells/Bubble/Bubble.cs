#region

using UnityEngine;

#endregion

public class Bubble : MonoBehaviour
{
	public static float bubbleDurationTemp;
	private static Bubble instance;
	[SerializeField] private float bubbleDuration;
	[SerializeField] private float movementSpeedFactor;
	private StatusEffect playerStatusEffect;

	private void Awake()
	{
		playerStatusEffect = GameObject.Find("Player").GetComponent<StatusEffect>();

		//Singleton
		if (instance != null)
		{
			playerStatusEffect.BecomeBubbled(movementSpeedFactor, bubbleDuration);
			Destroy(gameObject);
			return;
		}

		instance = this;
		playerStatusEffect.BecomeStatusEffectImmune(bubbleDuration);
		playerStatusEffect.BecomeBubbled(movementSpeedFactor, bubbleDuration);
		bubbleDurationTemp = bubbleDuration;
		Destroy(gameObject, bubbleDuration);
	}
}