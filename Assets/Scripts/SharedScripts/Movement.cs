#region

using UnityEngine;

#endregion

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour, IMovement
{
	[SerializeField] protected float movementSpeed;
	protected bool isXMovementSpeedLocked;
	protected float movementSpeedModifier;
	protected float movementSpeedTemp;
	protected Rigidbody2D rb;

	protected virtual void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		movementSpeedTemp = movementSpeed;
	}

	public virtual float GetMovementSpeed()
	{
		return movementSpeed;
	}

	public virtual float GetMovementSpeedModifier()
	{
		return movementSpeedModifier;
	}

	public virtual void SetLockXMovement(bool isLocked)
	{
		isXMovementSpeedLocked = isLocked;
		if (isLocked)
		{
			rb.velocity = new Vector2(0, rb.velocity.y);
		}
		else
		{
			movementSpeed = movementSpeedTemp + movementSpeedModifier;
		}
		
	}

	public virtual void SetMovementSpeedByAddition(float number)
	{
		movementSpeedModifier += number;
	}

	public virtual void SetMovementSpeedModifierToDefault()
	{
		movementSpeedModifier = 0;
	}
}