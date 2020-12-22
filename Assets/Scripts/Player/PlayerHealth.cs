using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour, IHealth
{
    [SerializeField] private float maxHealth;

    public static float currentHealth;
    private float currentHealthTemp; //used for GodMode
    private float damageModifier = 1;

    //not used atm. Set game over screen when this happens
    public event Action IsDead = delegate { };

    private void Start()
    {
        //if (SceneManager.GetActiveScene().buildIndex == 1)
        //{
        //    currentHealth = maxHealth;
        //}

        currentHealth = maxHealth;
    }

    private void Die()
    {
        if (currentHealth <= 0)
        {
            //do something
        }
    }

    //Godmode used for debugging purposes
    public void SetGodModeHealth()
    {
        currentHealthTemp = currentHealth;
        currentHealth += 10000;
    }

    public void SetGodModeHealthToNormal()
    {
        currentHealth = currentHealthTemp;
    }

    //used in ui
    public float GetMaxHealth()
    {
        return maxHealth;
    }

    //used in ui
    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public void TakeDamage(float damage, bool isStatusEffectDamage = false)
    {

        if(isStatusEffectDamage)
        {
            currentHealth -= damage;
        }
        else
        {
            damage = damage * damageModifier;
            currentHealth -= damage;
        }
        

        FlashWhenDamaged();

        if (currentHealth <= 0)
        {
            Die();
            IsDead();
        }

    }

    public void TakeHealing(float heal)
    {
        currentHealth += heal;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void FlashWhenDamaged()
    {
        if (GetComponent<FlashWhenDamaged>() != null)
        {
            GetComponent<FlashWhenDamaged>().FlashSprite();
        }
    }

    //Used by earth armor
    public void EarthArmorModifier(float modifier)
    {
        damageModifier = modifier;
    }

    //Used by earth armor
    public void ResetDamageModifier()
    {
        damageModifier = 1;
    }
}