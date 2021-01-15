using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(FlashWhenDamaged))]
public class Health : MonoBehaviour, IHealth
{
    [SerializeField] protected float maxHealth = 0;
    protected float currentHealth;
    protected bool isInvulnerable = false;
    protected float damageModifier = 1;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public virtual void SetIsInvulnerable(bool isInvulnerable)
    {
        this.isInvulnerable = isInvulnerable;
    }

    public virtual void TakeDamage(float damage, bool isStatusEffectDamage = false)
    {
        if (!isInvulnerable)
        {
            //damage not affected by damage modifier if it comes from status effect
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
        }
    }

    public virtual void TakeHealing(float healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    protected virtual void FlashWhenDamaged()
    {
        if (GetComponent<FlashWhenDamaged>() != null)
        {
            GetComponent<FlashWhenDamaged>().FlashSprite();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
