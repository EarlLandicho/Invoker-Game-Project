using System;
using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField] private float comboBarDecreaseValue;

    private float currentHealthTemp; //used for GodMode
    private ComboBar comboBar;

    public event Action IsDead = delegate { };

    private new void Awake()
    {
        base.Awake();
        comboBar = FindObjectOfType<ComboBar>();
    }

    public override void TakeDamage(float damage, bool isStatusEffectDamage = false)
    {
        if (!isInvulnerable)
        {
            if (isStatusEffectDamage)
            {
                currentHealth -= damage;
            }
            else
            {
                damage = damage * damageModifier;
                currentHealth -= damage;
            }
            FlashWhenDamaged();
            comboBar.DecreaseComboBarLevel(comboBarDecreaseValue);
        }

        if (currentHealth <= 0)
        {
            Die();
            IsDead();
        }
    }

    public void SetGodModeHealth(bool isGodMode)
    {
        if (isGodMode)
        {
            currentHealthTemp = currentHealth;
            currentHealth += 10000;
        }
        else
        {
            currentHealth = currentHealthTemp;
        }
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    protected override void Die()
    {
        gameObject.SetActive(false);
    }
}