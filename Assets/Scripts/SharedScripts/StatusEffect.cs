#region

using System.Collections;
using UnityEngine;

#endregion

[RequireComponent(typeof(Health))]
public class StatusEffect : MonoBehaviour
{
	[SerializeField] private bool isImmuneToBurning;
	[SerializeField] private bool isImmuneToPoison;
	[SerializeField] private bool isImmuneToOil;
	[SerializeField] private bool isImmuneToStun;
	[SerializeField] private GameObject poisonEffect;
	[SerializeField] private GameObject burnEffect;
	[SerializeField] private GameObject oilEffect;
	[SerializeField] private GameObject stunEffect;
	
	private float armorDamageModifier;
	private float armorDuration;
	private float bubbleDuration;
	private float bubbleMovementSpeedModifier;
	private float burningDamageAmountCounter;
	private EnemyAttack enemyAttack;
	private float healAmount;
	private float healAmountCounter;
	private float healDuration;

	//can make the health, movement, and jump an interface such that this file can be used by many characters
	private IHealth health;
	private bool isImmuneToBurningTemp;
	private bool isImmuneToOilTemp;
	private bool isImmuneToPoisonTemp;
	private bool isImmuneToStunTemp;
	private bool isOiled;
	private bool isTickHealing;
	private IJump jump;
	private IMovement movement;
	private float poisonDamageAmountCounter;
	private float statusEffectImmuneDuration;

	private GameObject currentPoisonEffect;
	private GameObject currentBurnEffect;
	private GameObject currentOilEffect;
	private GameObject currentStunEffect;

	private void Awake()
	{
		//when refactored, this will always refer to the gameobject it's attached to
		health = GetComponent<IHealth>();
		movement = GetComponent<IMovement>();
		if (GetComponent<IJump>() != null)
		{
			jump = GetComponent<IJump>();
		}

		if (GetComponent<EnemyAttack>() != null)
		{
			enemyAttack = GetComponent<EnemyAttack>();
		}

		isImmuneToBurningTemp = isImmuneToBurning;
		isImmuneToOilTemp = isImmuneToOil;
		isImmuneToPoisonTemp = isImmuneToPoison;
		isImmuneToStunTemp = isImmuneToStun;
	}

	public void BecomeArmored(float damageModifier, float duration)
	{
		Debug.Log(damageModifier);
		armorDuration = duration;
		armorDamageModifier = 1 - damageModifier;
		StartCoroutine("Armor", armorDamageModifier);
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
				RemovePoison();
			}

			currentPoisonEffect = Instantiate(poisonEffect, transform.position, transform.rotation);
			currentPoisonEffect.transform.parent = gameObject.transform;
			InvokeRepeating("Poison", 0, Constants.PoisonTickPerSecond);
		}
	}

	public void BecomeOiled()
	{
		if (!isImmuneToOilTemp)
		{
			if (isOiled)
			{
				RemoveOil();
			}
			currentOilEffect = Instantiate(oilEffect, transform.position, transform.rotation);
			currentOilEffect.transform.parent = gameObject.transform;
			StartCoroutine("Oil");
		}
	}

	public void BecomeBurned()
	{
		if (!isImmuneToBurningTemp)
		{
			if (IsInvoking("Burn"))
			{
				RemoveBurning();
			}
			currentBurnEffect = Instantiate(burnEffect, transform.position, transform.rotation);
			currentBurnEffect.transform.parent = gameObject.transform;
			InvokeRepeating("Burn", 0, Constants.BurningTickPerSecond);
		}
	}

	public void BecomeStunned()
	{
		if (!isImmuneToStunTemp)
		{
			StopCoroutine("Stun");
			StartCoroutine("Stun");
			
			currentStunEffect = Instantiate(stunEffect, transform.position, transform.rotation);
			currentStunEffect.transform.parent = gameObject.transform;
		}
	}

	public void TickHealing(float healAmount, float healDuration)
	{
		this.healAmount = healAmount;
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
		RemoveBurning();
		RemovePoison();
		RemoveOil();
		RemoveStun();

		// if (GetComponent<IEnemyAttack>() != null)
		// {
		// 	enemyAttack.SetLockAttack(true);
		// }
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

	private void RemovePoison()
	{
		poisonDamageAmountCounter = 0;
		CancelInvoke("Poison");
		Destroy(currentPoisonEffect);
	}

	private void RemoveBurning()
	{
		burningDamageAmountCounter = 0;
		CancelInvoke("Burn");
		Destroy(currentBurnEffect);
	}

	private void RemoveOil()
	{
		if (isOiled)
		{
			movement.SetMovementSpeedByAddition(Constants.OilMovementDecreaseNumber);
			if (GetComponent<IJump>() != null)
			{
				jump.SetJumpHeightToDefault();
			}

			isOiled = false;
			StopCoroutine("Oil");
			
			Destroy(currentOilEffect);
		}
	}
	
	private void RemoveStun()
	{
		if (GetComponent<IJump>() != null)
		{
			jump.SetLockJump(false);
		}

		movement.SetLockXMovement(false);
		Destroy(currentStunEffect);
	}

	private void Burn()
	{
		float burningTickDamage;
		if (isOiled)
		{
			burningTickDamage = Constants.BurningOiledDamageAmount * Constants.BurningTickPerSecond /
								Constants.BurningDuration;
		}
		else
		{
			burningTickDamage = Constants.BurningDamageAmount * Constants.BurningTickPerSecond /
								Constants.BurningDuration;
		}

		health.TakeDamage(burningTickDamage, true);
		burningDamageAmountCounter += burningTickDamage;
		if (burningDamageAmountCounter >= Constants.BurningDamageAmount)
		{
			RemoveBurning();
		}
	}

	private void Poison()
	{
		float poisonTickDamage = Constants.PoisonDamageAmount * Constants.PoisonTickPerSecond / Constants.PoisonDuration;
		health.TakeDamage(poisonTickDamage, true);
		poisonDamageAmountCounter += poisonTickDamage;
		if (poisonDamageAmountCounter >= Constants.PoisonDamageAmount)
		{
			RemovePoison();
		}
	}

	private void TickHeal()
	{
		float healTick = healAmount * Constants.HealTickPerSecond / healDuration;
		health.TakeHealing(healTick);
		healAmountCounter += healTick;
		if (healAmountCounter >= healAmount)
		{
			healAmountCounter = 0;
			CancelInvoke("TickHeal");
		}
	}

	private IEnumerator Oil()
	{
		isOiled = true;
		movement.SetMovementSpeedByAddition(-Constants.OilMovementDecreaseNumber);
		if (GetComponent<IJump>() != null)
		{
			jump.SetJumpHeightToDefault();
			jump.SetJumpHeightByFactor(Constants.OilJumpHeightDecreaseFactor);
		}

		yield return new WaitForSeconds(Constants.OilDuration);
		RemoveOil();
	}

	private IEnumerator Stun()
	{
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
		Destroy(currentStunEffect);
	}

	private IEnumerator Armor(float modifier)
	{
		health.SetDamageModifierByFactor(modifier, true);
		yield return new WaitForSeconds(armorDuration);
		health.SetDamageModifierByFactor(modifier, false);
	}

	private IEnumerator Bubble()
	{
		movement.SetMovementSpeedByAddition(bubbleMovementSpeedModifier);
		yield return new WaitForSeconds(bubbleDuration);
		movement.SetMovementSpeedByAddition(-bubbleMovementSpeedModifier);

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