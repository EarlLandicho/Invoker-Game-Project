#region

using UnityEngine;

#endregion

public class EnemyFlyingStraightMovement : EnemyMovement
{
	[SerializeField] private Transform wallCheck;
	[SerializeField] private Transform upperWallCheck;
	[SerializeField] private Transform lowerWallCheck;
	private Vector2 targetToMoveTo;

	protected override void Awake()
	{
		base.Awake();
		MovementCheck();
	}

	private void Update()
	{
		WallCheck();
		UpperWallCheck();
		LowerWallCheck();
		if (!isXMovementSpeedLocked)
		{
			rb.velocity = targetToMoveTo * movementSpeed;
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(wallCheck.position, 0.04f);
		Gizmos.DrawWireSphere(upperWallCheck.position, 0.04f);
		Gizmos.DrawWireSphere(lowerWallCheck.position, 0.04f);
	}

	// Called in Animator
	public void MovementCheck()
	{
		targetToMoveTo = ExtensionMethods.GetNormalizedDirectionToPlayer2D(gameObject);
	}

	private void WallCheck()
	{
		if (Physics2D.OverlapCircle(new Vector2(wallCheck.position.x, wallCheck.position.y), 0.04f,
									1 << LayerMask.NameToLayer("Ground")))
		{
			targetToMoveTo = Vector2.right;
		}
	}

	private void UpperWallCheck()
	{
		if (Physics2D.OverlapCircle(new Vector2(upperWallCheck.position.x, upperWallCheck.position.y), 0.04f,
									1 << LayerMask.NameToLayer("Ground")))
		{
			targetToMoveTo = Vector2.down;
		}
	}

	private void LowerWallCheck()
	{
		if (Physics2D.OverlapCircle(new Vector2(lowerWallCheck.position.x, lowerWallCheck.position.y), 0.04f,
									1 << LayerMask.NameToLayer("Ground")))
		{
			targetToMoveTo = Vector2.up;
		}
	}
}