#region

using UnityEngine;
using UnityEngine.UI;

#endregion

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
	private PlayerHealth playerHealth;
	private Slider slider;

	private void Awake()
	{
		slider = GetComponent<Slider>();
		playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
	}

	private void LateUpdate()
	{
		SetHealth(playerHealth.GetCurrentHealth());
	}

	private void SetHealth(float health)
	{
		slider.value = health;
	}
}