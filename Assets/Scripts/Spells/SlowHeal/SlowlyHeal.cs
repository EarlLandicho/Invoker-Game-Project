#region

using System.Collections;
using UnityEngine;

#endregion

public class SlowlyHeal : MonoBehaviour
{
	[SerializeField] private float healTotalAmount;
	[SerializeField] private float healDuration;
	private StatusEffect statusEffect;

	private void Awake()
	{
		statusEffect = GameObject.Find("Player").GetComponent<StatusEffect>();
		statusEffect.Dispel();
		statusEffect.TickHealing(healTotalAmount, healDuration);
		StartCoroutine("DestroyThis");
	}

	private IEnumerator DestroyThis()
	{
		yield return new WaitForSeconds(healDuration);
		Destroy(gameObject);
	}
}