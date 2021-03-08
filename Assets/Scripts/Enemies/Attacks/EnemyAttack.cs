#region

using UnityEngine;

#endregion

public class EnemyAttack : MonoBehaviour
{
	[SerializeField] protected GameObject projectile;
	[SerializeField] protected float damage;
	[SerializeField] protected float attackSpeed;
	protected float attackSpeedTemp;
	protected bool isLockedAttack;
	protected GameObject playerObject;

	protected void Awake()
	{
		playerObject = GameObject.Find("Player");
		attackSpeedTemp = attackSpeed;
	}

	public virtual void SetLockAttack(bool isStunned)
	{
		isLockedAttack = isStunned;
	}

	protected Vector2 GetNormalizedDirectionToPlayer2D()
	{
		return (playerObject.transform.position - transform.position).normalized;
	}
}