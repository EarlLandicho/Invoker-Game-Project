#region

using UnityEngine;

#endregion

public class EnemyFollowMovement : EnemyMovement
{
	private void FixedUpdate()
	{
		if (!isXMovementSpeedLocked)
		{
			Vector2 playerDirection = ExtensionMethods.GetNormalizedDirectionToPlayer2D(gameObject);
			rb.velocity = playerDirection * movementSpeed;
		}
	}
}