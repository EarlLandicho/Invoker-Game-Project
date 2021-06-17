#region

using EasyFeedback;
using UnityEngine;

#endregion

public class PlayerJump : MonoBehaviour, IJump
{
	[SerializeField] private float jumpHeight;
	[SerializeField] private LayerMask groundLayer;
	private AudioSource audioSource;
	private Transform groundCheck;
	private bool isGrounded;
	private bool isGroundedLedge;
	private float jumpHeightTemp;
	private Rigidbody2D rb;
	private bool jumpIsLocked;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		audioSource = GameObject.Find("PlayerJump").GetComponent<AudioSource>();
		groundCheck = transform.Find("GroundCheck");
		jumpHeightTemp = jumpHeight;
	}

	private void Update()
	{
		if (!FeedbackForm.formIsOpened && !jumpIsLocked)
		{
			JumpCheck();
		}
	}

	private void FixedUpdate()
	{
		JumpAbleCheck();
	}

	public void SetLockJump(bool isLocked)
	{
		jumpIsLocked = isLocked;
	}

	public void SetJumpHeightByFactor(float factor)
	{
		jumpHeight *= factor;
	}

	public void SetJumpHeightToDefault()
	{
		jumpHeight = jumpHeightTemp;
	}

	public bool GetIsGrounded()
	{
		return isGrounded;
	}

	public bool GetIsGroundedLedge()
	{
		return isGroundedLedge;
	}

	public void Jump()
	{
		rb.velocity = transform.up * jumpHeight;
		audioSource.Play();
	}

	private void JumpAbleCheck()
	{
		if (Physics2D.OverlapCircle(groundCheck.position, 0.05f, 1 << LayerMask.NameToLayer("Ground")) && rb.velocity.y <= 0.01f)
		{
			isGrounded = true;
		}
		else
		{
			isGrounded = false;
		}
		
		if (Physics2D.OverlapCircle(groundCheck.position, 0.05f, 1 << LayerMask.NameToLayer("Ledge")) && rb.velocity.y <= 0.01f)
		{
			isGroundedLedge = true;
		}
		else
		{
			isGroundedLedge = false;
		}
	}

	private void JumpCheck()
	{
		if (Input.GetButtonDown("Jump") && (isGrounded || isGroundedLedge))
		{
			Jump();
		}
	}

	//private void OnDrawGizmos()
	//{
	//    Gizmos.DrawWireSphere(groundCheck.position, 0.05f);
	//}
}