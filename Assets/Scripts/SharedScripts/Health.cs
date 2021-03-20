#region

using System;
using UnityEngine;

#endregion

[RequireComponent(typeof(FlashWhenDamaged))]
[RequireComponent(typeof(StatusEffect))]
public class Health : MonoBehaviour, IHealth
{
	[SerializeField] protected float maxHealth;
	[SerializeField] private float comboBarAddedHealth = 20;
	protected float currentHealth;
	protected float damageModifier = 1;
	protected bool isInvulnerable;
	
	private ComboBar comboBar;
	private float healthTemp;
	
	protected void Awake()
	{
		comboBar = GameObject.Find("GameManager").GetComponent<ComboBar>();
	}

	private void Start()
	{
		ComboBarCheck();
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

	public virtual float GetDamageModifier()
	{
		return damageModifier;
	}

	public virtual void SetDamageModifierByFactor(float factor, bool isSetting)
	{
		if (isSetting)
		{
			damageModifier *= factor;
			Debug.Log("damage modifier set to" + damageModifier);
		}
		else
		{
			damageModifier /= factor;
			Debug.Log("damage modifier reset to " + damageModifier);
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
	
	private void ComboBarCheck()
	{
		switch (comboBar.GetComboBarStage())
		{
			case 1:
				currentHealth = maxHealth;
				break;
			case 2:
				currentHealth = maxHealth + comboBarAddedHealth;
				break;
			case 3:
				currentHealth = maxHealth + 2 * comboBarAddedHealth;
				break;
			default:
				return;
		}
	}
}