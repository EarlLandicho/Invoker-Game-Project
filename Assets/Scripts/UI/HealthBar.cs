using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void LateUpdate()
    {
        SetHealth(PlayerHealth.currentHealth);
    }

    private void SetHealth(float health)
    {
        slider.value = health;
    }
}