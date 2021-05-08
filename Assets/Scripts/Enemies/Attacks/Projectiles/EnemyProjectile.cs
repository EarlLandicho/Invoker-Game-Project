#region

using UnityEngine;

#endregion

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyProjectile : MonoBehaviour
{
	protected Animator animator;
	private float damage;
	private Vector2 playerDirection;
	private Rigidbody2D projectileRigidbody;
	private float projectileSpeed;

	protected virtual void Awake()
	{
		projectileRigidbody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Player") ||
			other.gameObject.layer == LayerMask.NameToLayer("Ally"))
		{
			other.GetComponent<IHealth>().TakeDamage(damage);
			animator.SetTrigger("hasHitSomething");
		}
		else if (other.gameObject.layer == LayerMask.NameToLayer("Ground") ||
				 other.gameObject.layer == LayerMask.NameToLayer("Player Projectile"))
		{
			animator.SetTrigger("hasHitSomething");
		}
	}

	public void SetDamage(float damage)
	{
		this.damage = damage;
	}

	public void SetPlayerDirection(Vector2 playerDirection)
	{
		this.playerDirection = playerDirection;
	}

	public void SetProjectileSpeed(float projectileSpeed)
	{
		this.projectileSpeed = projectileSpeed;
	}

	public void Launch()
	{
		projectileRigidbody.velocity = projectileSpeed * playerDirection;
	}

	// Called by animator
	public void DestroyThisObject()
	{
		Destroy(gameObject);
	}

	// Called by animator
	public virtual void StopMovement()
	{
		projectileRigidbody.velocity = new Vector2(0, 0);
	}

	public void DestroyWithAnimation()
	{
		animator.SetTrigger("hasHitSomething");
	}
}