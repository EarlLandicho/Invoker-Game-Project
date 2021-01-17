using System;
using UnityEngine;

public class PlayerHealth : Health
{
    private float currentHealthTemp; //used for GodMode

    public event Action IsDead = delegate { };

    private void Start()
    {
        //if (SceneManager.GetActiveScene().buildIndex == 1)
        //{
        //    currentHealth = maxHealth;
        //}

        currentHealth = maxHealth;
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
        }

        if (currentHealth <= 0)
        {
            Die();
            IsDead();
        }
    }

    public override void SetIsInvulnerable(bool isInvulnerable)
    {
        this.isInvulnerable = isInvulnerable;
    }

    public void SetGodModeHealth(bool isGodMode)
    {
        if(isGodMode)
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
}