#region

using UnityEngine;

#endregion

public class EnemyMovement : Movement
{
	[SerializeField] protected bool isFlying;
	protected bool movementIsPaused;
	protected GameObject playerObject;

	protected override void Awake()
	{
		base.Awake();
		playerObject = GameObject.Find("Player");
	}

	public virtual void OnCollisionEnter2D(Collision2D collision)
	{
		if (isFlying)
		{
			if (collision.gameObject.layer == LayerMask.NameToLayer("Ledge"))
			{
				Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);
				;
			}
		}
	}

	protected bool PlayerIsOnTheRight()
	{
		if (playerObject.transform.position.x - transform.position.x < 0)
		{
			return false;
		}

		return true;
	}

	// Called in Animator
	public void PauseMovement()
	{
		isXMovementSpeedLocked = true;
		if (isFlying)
		{
			rb.velocity = new Vector2(0, 0);
		}
		else
		{
			rb.velocity = new Vector2(0, rb.velocity.y);
		}

		
	}

	// Called in Animator
	public void UnpauseMovement()
	{
		isXMovementSpeedLocked = false;
	}
	
	public override void SetLockXMovement(bool isLocked)
	{
		isXMovementSpeedLocked = isLocked;
		if (isLocked)
		{
			rb.velocity = isFlying ? new Vector2(0, 0) : new Vector2(0, rb.velocity.y);
		}
		else
		{
			movementSpeed = movementSpeedTemp + movementSpeedModifier;
		}
	}
}