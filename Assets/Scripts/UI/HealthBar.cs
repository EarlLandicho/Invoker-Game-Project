using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    private Slider slider;
    private PlayerHealth playerHealth;

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