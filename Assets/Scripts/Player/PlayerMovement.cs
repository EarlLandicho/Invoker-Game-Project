#region

using EasyFeedback;
using UnityEngine;

#endregion

public class PlayerMovement : Movement
{
	private bool isFlying;
	private bool isHibernating;

	private void Update()
	{
		if (!FeedbackForm.formIsOpened)
		{
			MoveCheck();
		}
	}

	public void SetIsFlying(bool isFlying)
	{
		this.isFlying = isFlying;
	}

	public void SetisHibernating(bool isHibernating)
	{
		this.isHibernating = isHibernating;
	}

	public bool GetIsHibernating()
	{
		return isHibernating;
	}

	private void MoveCheck()
	{
		if (!isXMovementSpeedLocked && !isFlying && !isHibernating)
		{
			rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * (movementSpeed + movementSpeedModifier),
									  rb.velocity.y);
			Debug.Log(rb.velocity);
		}
		else if (isFlying)
		{
			rb.velocity = new Vector2(Input.GetAxis("Horizontal") * (movementSpeed + movementSpeedModifier),
									  rb.velocity.y);
			rb.velocity = new Vector2(rb.velocity.x, Input.GetAxis("Vertical") * (movementSpeed + movementSpeedModifier));
		}
		else if (!isFlying && isHibernating)
		{
			rb.velocity = new Vector2(0, rb.velocity.y);
		}
	}
}