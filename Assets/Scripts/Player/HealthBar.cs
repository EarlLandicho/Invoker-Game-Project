using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    private Slider slider;

    void Awake()
    {
        slider = GetComponent<Slider>();
        
    }

    void LateUpdate()
    {
        SetHealth(PlayerHealth.currentHealth);
        
    }


    private void SetHealth(float health)
    {
        slider.value = health;
    }

}
