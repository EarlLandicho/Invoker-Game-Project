using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class StatusEffect : MonoBehaviour
{
    [SerializeField] private bool isImmuneToBurning;
    [SerializeField] private bool isImmuneToPoison;
    [SerializeField] private bool isImmuneToOil;
    [SerializeField] private bool isImmuneToStun;
    private bool isImmuneToBurningTemp;
    private bool isImmuneToPoisonTemp;
    private bool isImmuneToOilTemp;
    private bool isImmuneToStunTemp;


    //can make the health, movement, and jump an interface such that this file can be used by many characters
    private IHealth health;
    private IMovement movement;
    private IJump jump;
    private EnemyAttack enemyAttack;

    private float poisonDamageAmountCounter;
    private float burningDamageAmountCounter;
    private float healAmountCounter;

    private float healAmount;
    private float healDuration;

    private float armorDuration;
    private float armorDamageModifier;

    private float bubbleDuration;
    private float bubbleMovementSpeedModifier;

    private float statusEffectImmuneDuration;

    private bool isBurning = false;
    private bool isPoisoned = false;
    private bool isOiled = false;
    private bool isTickHealing = false;
    private bool isStunned = false;

    private void Awake()
    {
       
        //when refactored, this will always refer to the gameobject it's attached to
        health = GetComponent<IHealth>();
        movement = GetComponent<IMovement>();
        


        if (GetComponent<IJump>() != null)
        {
            jump = GetComponent<IJump>();

        }

        if(GetComponent<EnemyAttack>() != null)
        {
            enemyAttack = GetComponent<EnemyAttack>();
        }

        isImmuneToBurningTemp = isImmuneToBurning;
        isImmuneToOilTemp = isImmuneToOil;
        isImmuneToPoisonTemp = isImmuneToPoison;
        isImmuneToStunTemp = isImmuneToStun;

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

    public void BecomeArmored(float damageModifier, float duration)
    {
        armorDuration = duration;
        armorDamageModifier = 1 - damageModifier;
        StartCoroutine("Armor");
    }

    public void BecomeBubbled(float movementSpeedModifier, float duration)
    {
        bubbleDuration = duration;
        bubbleMovementSpeedModifier = movementSpeedModifier;
        StartCoroutine("Bubble");
    }

    public void BecomePoisoned()
    {
        if (!isImmuneToPoisonTemp)
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
        if(!isImmuneToOilTemp)
        {
            //stopping first to reset the cooldown
            StartCoroutine("Oil");

        }
    }

    public void BecomeBurned()
    {
        if (!isImmuneToBurningTemp)
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
        if (!isImmuneToStunTemp)
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


        isOiled = false;
        StopCoroutine("Oil");

        //sets movementSppedModiier to 1
        movement.SetMovementSpeedModifierToDefault();
        jump.SetJumpHeightToDefault();


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
            enemyAttack.SetLockAttack(true);
        }
        if (GetComponent<IJump>() != null)
        {
            jump.SetLockJump(false);

        }
        movement.SetLockXMovement(false);
    }

    public void BecomeInvulnerable(bool isInvulnerable)
    {
        health.SetIsInvulnerable(isInvulnerable);
    }

    public void BecomeStatusEffectImmune(float duration)
    {
        statusEffectImmuneDuration = duration;
        StopCoroutine("StatusEffectImmune");
        StartCoroutine("StatusEffectImmune");

        
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

    private IEnumerator Oil()
    {
        isOiled = true;

        movement.SetMovementSpeedByFactor(Constants.OilMovementDecreseFactor, true);

        if (GetComponent<IJump>() != null)
        {
            jump.SetJumpHeightToDefault();
            jump.SetJumpHeightByFactor(Constants.OilJumpHeightDecreseFactor);
        }
        
        yield return new WaitForSeconds(Constants.OilDuration);

        movement.SetMovementSpeedByFactor(Constants.OilMovementDecreseFactor, false);

        if (GetComponent<IJump>() != null)
        {
            jump.SetJumpHeightToDefault();
        }
        
        isOiled = false;
    }

    private IEnumerator Stun()
    {
        isStunned = true;
        if (GetComponent<IJump>() != null)
        {
            jump.SetLockJump(true);

        }

        if (GetComponent<EnemyAttack>() != null)
        {
            enemyAttack.SetLockAttack(true);
        }
        movement.SetLockXMovement(true);

        yield return new WaitForSeconds(Constants.StunDuration);

        if (GetComponent<IJump>() != null)
        {
            jump.SetLockJump(false);

        }

        if (GetComponent<EnemyAttack>() != null)
        {
            enemyAttack.SetLockAttack(false);
        }
        movement.SetLockXMovement(false);


    }

    private IEnumerator Armor()
    {
        health.SetDamageModifierByFactor(armorDamageModifier, true);

        yield return new WaitForSeconds(armorDuration);

        health.SetDamageModifierByFactor(armorDamageModifier, false);
    }

    private IEnumerator Bubble()
    {
        movement.SetMovementSpeedByFactor(bubbleMovementSpeedModifier, true);
        
        yield return new WaitForSeconds(bubbleDuration);

        movement.SetMovementSpeedByFactor(bubbleMovementSpeedModifier, false);
    }

    private IEnumerator StatusEffectImmune()
    {
        isImmuneToBurningTemp = true;
        isImmuneToPoisonTemp = true;
        isImmuneToOilTemp = true;
        isImmuneToStunTemp = true;

        yield return new WaitForSeconds(statusEffectImmuneDuration);

        isImmuneToBurningTemp = isImmuneToBurning;
        isImmuneToPoisonTemp = isImmuneToPoison;
        isImmuneToOilTemp = isImmuneToOil;
        isImmuneToStunTemp = isImmuneToStun;
    }
}