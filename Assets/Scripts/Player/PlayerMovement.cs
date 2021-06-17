#region

using EasyFeedback;
using UnityEngine;

#endregion

public class PlayerMovement : Movement
{
	private bool isFlying;
	private bool isHibernating;
	private AudioSource audioSource;
	private bool isMoving;
	private bool isPlayingAudio;
	private PlayerJump playerJump;

	protected override void Awake()
	{
		base.Awake();
		audioSource = GameObject.Find("PlayerWalk").GetComponent<AudioSource>();
		playerJump = GetComponent<PlayerJump>();
	}

	private void Update()
	{
		if (!FeedbackForm.formIsOpened)
		{
			MoveCheck();
			if (isMoving && !isPlayingAudio && (playerJump.GetIsGrounded() || playerJump.GetIsGroundedLedge()))
			{
				audioSource.Play();
				isPlayingAudio = true;
			}
			else if ((!isMoving || !(playerJump.GetIsGrounded() || playerJump.GetIsGroundedLedge())) && isPlayingAudio)
			{
				audioSource.Stop();
				isPlayingAudio = false;
			}
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
			rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * (movementSpeed + movementSpeedModifier), rb.velocity.y);
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

		isMoving = rb.velocity.x > 0.1f || rb.velocity.x < -0.1f;
	}
}