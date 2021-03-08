#region

using UnityEngine;

#endregion

public class EnemyFollowMovement : EnemyMovement
{
	private void FixedUpdate()
	{
		if (!isXMovementSpeedLocked)
		{
			var playerDirection = ExtensionMethods.GetNormalizedDirectionToPlayer2D(gameObject);
			rb.velocity = playerDirection * movementSpeed;
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
		}
	}
}