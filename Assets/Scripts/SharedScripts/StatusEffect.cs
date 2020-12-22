using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffect : MonoBehaviour, IStatusEffect
{
    //can make the health, movement, and jump an interface such that this file can be used by many characters
    private IHealth health;
    private IMovement movement;
    private IJump jump;

    private float poisonDamageAmountCounter = 0;
    private float burningDamageAmountCounter = 0;
    private float healAmountCounter = 0;

    private float healAmount = 0;
    private float healDuration = 0;

    private bool isBurning = false;
    private bool isPoisoned = false;
    private bool isOiled = false;
    private bool isTickHealing = false;

    void Awake()
    {
        //when refactored, this will always refer to the gameobject it's attached to
        health = GetComponent<IHealth>();
        movement = GetComponent<IMovement>();
        jump = GetComponent<IJump>();
    }

    //public bool GetIsPoisoned()
    //{
    //    return isPoisoned;
    //}

    //public bool GetIsBurning()
    //{
    //    return isBurning;
    //}

    //public bool GetIsOiled()
    //{
    //    return isOiled;
    //}

    //public bool GetIsTickHealing()
    //{
    //    return isTickHealing;
    //}

    public void BecomePoisoned()
    {
        if (IsInvoking("Poison"))
        {
            CancelInvoke("Poison");
            poisonDamageAmountCounter = 0;
            InvokeRepeating("Poison", 0, Constants.PoisonTickPerSecond);
        }
        else
        {
            InvokeRepeating("Poison", 0, Constants.PoisonTickPerSecond);
        }
    }

    public void BecomeOiled()
    {
        //stopping first to reset the cooldown
        StopCoroutine("Oil");
        StartCoroutine("Oil");
    }

    public void BecomeBurned()
    {
        if (IsInvoking("Burn"))
        {
            CancelInvoke("Burn");
            burningDamageAmountCounter = 0;
            InvokeRepeating("Burn", 0, Constants.BurningTickPerSecond);
        }
        else
        {
            InvokeRepeating("Burn", 0, Constants.BurningTickPerSecond);
        }
    }

    public void TickHealing(float healAmount, float healDuration)
    {
        this.healAmount = healAmount;
        this.healDuration = healDuration;

        if (IsInvoking("TickHealing"))
        {
            CancelInvoke("TickHeal");
            InvokeRepeating("TickHeal", 0, Constants.HealTickPerSecond);
        }
        else
        {
            InvokeRepeating("TickHeal", 0, Constants.HealTickPerSecond);
        }


    }

    //will be used by spells
    public void Dispel()
    {
        CancelInvoke();
        StopAllCoroutines();
    }

    private void Burn()
    {
        isBurning = true;
        float burningTickDamage;

        if (isOiled)
        {
            burningTickDamage = Constants.BurningOiledDamageAmount * Constants.BurningTickPerSecond / Constants.BurningDuration;
        }
        else
        {
            burningTickDamage = Constants.BurningDamageAmount * Constants.BurningTickPerSecond / Constants.BurningDuration;
        }


        health.TakeDamage(burningTickDamage, true);

        burningDamageAmountCounter += burningTickDamage;

        if (burningDamageAmountCounter >= Constants.BurningDamageAmount)
        {
            burningDamageAmountCounter = 0;
            isBurning = false;
            CancelInvoke("Burn");
        }
    }

    private void Poison()
    {
        isPoisoned = true;
        float poisonTickDamage = Constants.PoisonDamageAmount * Constants.PoisonTickPerSecond / Constants.PoisonDuration;

        health.TakeDamage(poisonTickDamage, true);

        poisonDamageAmountCounter += poisonTickDamage;

        if (poisonDamageAmountCounter >= Constants.PoisonDamageAmount)
        {
            poisonDamageAmountCounter = 0;
            isPoisoned = false;
            CancelInvoke("Poison");
        }
    }

    private IEnumerator Oil()
    {
        isOiled = true;
        movement.SetMovementSpeedByFactor(Constants.OilMovementDecreseFactor);
        jump.SetJumpHeightByFactor(Constants.OilJumpHeightDecreseFactor);

        yield return new WaitForSeconds(Constants.OilDuration);

        movement.SetSpeedToDefault();
        jump.SetJumpHeightToDefault();
        isOiled = false;

    }

    private void TickHeal()
    {
        isTickHealing = true;
        float healTick = healAmount * Constants.HealTickPerSecond / healDuration;
        health.TakeHealing(healTick);


        healAmountCounter += healTick;
        if (healAmountCounter >= healAmount)
        {
            isTickHealing = false;
            CancelInvoke("TickHeal");
        }
    }



}
