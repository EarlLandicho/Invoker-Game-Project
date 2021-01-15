using System.Collections;
using UnityEngine;

public class StatusEffect : MonoBehaviour, IStatusEffect
{
    //can make the health, movement, and jump an interface such that this file can be used by many characters
    private IHealth health;

    private IMovement movement;
    private IJump jump;
    private IEnemyAttack enemyAttack;

    private float poisonDamageAmountCounter = 0;
    private float burningDamageAmountCounter = 0;
    private float healAmountCounter = 0;

    private float healAmount = 0;
    private float healDuration = 0;

    private bool isBurning = false;
    private bool isPoisoned = false;
    private bool isOiled = false;
    private bool isTickHealing = false;
    private bool isStunned = false;
    private bool isStatusEffectImmune = false;

    private void Awake()
    {
        //when refactored, this will always refer to the gameobject it's attached to
        health = GetComponent<IHealth>();
        movement = GetComponent<IMovement>();
        

        if(GetComponent<IJump>() != null)
        {
            jump = GetComponent<IJump>();

        }

        if(GetComponent<IEnemyAttack>() != null)
        {
            enemyAttack = GetComponent<IEnemyAttack>();
        }
    }

    public bool GetIsPoisoned()
    {
        return isPoisoned;
    }

    public bool GetIsBurning()
    {
        return isBurning;
    }

    public bool GetIsOiled()
    {
        return isOiled;
    }

    public bool GetIsTickHealing()
    {
        return isTickHealing;
    }

    public bool GetIsStunned()
    {
        return isStunned;
    }

    public void BecomePoisoned()
    {
        if (!isStatusEffectImmune)
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

    }

    public void BecomeOiled()
    {
        if(!isStatusEffectImmune)
        {
            //stopping first to reset the cooldown
            StopCoroutine("Oil");
            StartCoroutine("Oil");

        }
    }

    public void BecomeBurned()
    {
        if (!isStatusEffectImmune)
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
    }

    public void BecomeStunned()
    {
        if (!isStatusEffectImmune)
        {
            StopCoroutine("Stun");
            StartCoroutine("Stun");

        }
    }

    public void TickHealing(float healAmount, float healDuration)
    {
        this.healAmount = this.healAmount + healAmount;
        this.healDuration = healDuration;

        if (IsInvoking("TickHeal"))
        {
            healAmountCounter = 0;
            CancelInvoke("TickHeal");
            InvokeRepeating("TickHeal", 0, Constants.HealTickPerSecond);
        }
        else
        {
            InvokeRepeating("TickHeal", 0, Constants.HealTickPerSecond);
        }
    }

    public void Dispel()
    {
        burningDamageAmountCounter = 0;
        isBurning = false;
        CancelInvoke("Burn");

        poisonDamageAmountCounter = 0;
        isPoisoned = false;
        CancelInvoke("Poison");

        movement.SetSpeedToDefault();
        if (GetComponent<IJump>() != null)
        {
            jump.SetJumpHeightToDefault();
        }
        isOiled = false;

        isTickHealing = false;
        healAmountCounter = 0;
        CancelInvoke("TickHeal");

        if (GetComponent<IEnemyAttack>() != null)
        {
            enemyAttack.SetLockAttack(false);
        }
        if (GetComponent<IJump>() != null)
        {
            jump.SetLockJump(false);

        }
        movement.SetLockMovement(false);
    }

    public void BecomeInvulnerable(bool isInvulnerable)
    {
        health.SetIsInvulnerable(isInvulnerable);
    }

    public void BecomeStatusEffectImmune(bool isStatusEffectImmune)
    {
        this.isStatusEffectImmune = isStatusEffectImmune;
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

        movement.SetSpeedToDefault();
        movement.SetMovementSpeedByFactor(Constants.OilMovementDecreseFactor);

        if (GetComponent<IJump>() != null)
        {
            jump.SetJumpHeightToDefault();
            jump.SetJumpHeightByFactor(Constants.OilJumpHeightDecreseFactor);
        }
        

        yield return new WaitForSeconds(Constants.OilDuration);

        movement.SetSpeedToDefault();
        if (GetComponent<IJump>() != null)
        {
            jump.SetJumpHeightToDefault();
        }
        
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
            healAmountCounter = 0;
            healAmount = 0;
            CancelInvoke("TickHeal");
        }
    }

    private IEnumerator Stun()
    {
        isStunned = true;
        if (GetComponent<IEnemyAttack>() != null)
        {
            enemyAttack.SetLockAttack(true);
        }
        if (GetComponent<IJump>() != null)
        {
            jump.SetLockJump(true);

        }
        movement.SetLockMovement(true);

        yield return new WaitForSeconds(Constants.StunDuration);

        if (GetComponent<IEnemyAttack>() != null)
        {
            enemyAttack.SetLockAttack(false);
        }
        if (GetComponent<IJump>() != null)
        {
            jump.SetLockJump(false);

        }
        movement.SetLockMovement(false);


    }
}