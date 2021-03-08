#region

using UnityEngine;

#endregion

public class EnemyHealth : Health
{
	[SerializeField] private GameObject deathAnimationObject;
	[SerializeField] private float comboBarIncreaseAmount = 5;
	private ComboBar comboBar;

	private new void Awake()
	{
		base.Awake();
		comboBar = FindObjectOfType<ComboBar>();
	}

	protected override void Die()
	{
		comboBar.IncreaseComboBarLevel(comboBarIncreaseAmount);
		Instantiate(deathAnimationObject, transform.position, transform.rotation);
		Destroy(gameObject);
	}

	private void SelfDie()
	{
		Instantiate(deathAnimationObject, transform.position, transform.rotation);
		Destroy(gameObject);
	}
}