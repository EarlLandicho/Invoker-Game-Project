#region

using UnityEngine;

#endregion

public class TrampolineDamage : MonoBehaviour
{
	[SerializeField] private float damage;
	[SerializeField] private Vector2 size = new Vector2(0, 0);
	[SerializeField] private GameObject projectile;
	private Animator animator;
	private TrampolineJump trampolineJump;

	private void Awake()
	{
		trampolineJump = GetComponent<TrampolineJump>();
		animator = GetComponent<Animator>();
		trampolineJump.TrampolineJumped += DamageEnemy;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.white;
		Gizmos.DrawWireCube((Vector2) transform.position, size);
	}

	private void DamageEnemy()
	{
		animator.SetTrigger("attack");
		Collider2D[] enemies = Physics2D.OverlapBoxAll(transform.position, size, 0, 1 << LayerMask.NameToLayer("Enemy"));
		foreach (Collider2D enemy in enemies)
		{
			enemy.gameObject.GetComponent<IHealth>().TakeDamage(damage);
		}

		AnimateProjectile();
	}

	private void AnimateProjectile()
	{
		Instantiate(projectile, transform.position, transform.rotation).GetComponent<TrampolineProjectile>()
																	   .SetIsRight(true);
		Instantiate(projectile, transform.position, transform.rotation).GetComponent<TrampolineProjectile>()
																	   .SetIsRight(false);
	}
}