using System;

public class PlayerHealth : Health
{
    private float currentHealthTemp; //used for GodMode

    public event Action IsDead = delegate { };

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