#region

using UnityEngine;

#endregion

public class GoblinMovement : EnemyMovement
{
	private Vector2 targetToMoveTo;
	private readonly bool willAdvanceTowardPlayer = true;

	private void Update()
	{
		if (!isXMovementSpeedLocked)
		{
			if (willAdvanceTowardPlayer)
			{
				rb.velocity = targetToMoveTo * movementSpeed;
			}
			else
			{
				rb.velocity = -1 * targetToMoveTo * movementSpeed;
			}
		}
	}

	public override void OnCollisionEnter2D(Collision2D collision)
	{
		base.OnCollisionEnter2D(collision);
		var collider = collision.collider;
		if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
		{
			Vector3 contactPoint = collision.contacts[0].point;
			var center = collider.bounds.center;
			var top = contactPoint.y > center.y;
			var right = contactPoint.x > center.x;
			if (top)
			{
				targetToMoveTo = transform.up;
			}
			else
			{
				targetToMoveTo = -transform.up;
			}

			if (right)
			{
				targetToMoveTo = transform.right;
			}
			else
			{
				targetToMoveTo = -transform.right;
			}
		}
	}

	public override void SetLockXMovement(bool isLocked)
	{
		isXMovementSpeedLocked = isLocked;
		if (isLocked)
		{
			rb.velocity = new Vector2(0, 0);
		}
		else
		{
			movementSpeed = movementSpeedTemp * movementSpeedModifier;
			MovementCheck();
		}
	}

	private void MovementCheck()
	{
		targetToMoveTo = ExtensionMethods.GetNormalizedDirectionToPlayer2D(gameObject);
	}
}