#region

using UnityEngine;

#endregion

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
	private Animator animator;
	private PlayerJump playerJump;
	private Rigidbody2D rb;

	private void Awake()
	{
		animator = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		playerJump = GetComponent<PlayerJump>();
	}

	private void Update()
	{
		animator.SetFloat("velocityX", Mathf.Abs(rb.velocity.x));
		animator.SetFloat("velocityY", rb.velocity.y);
		animator.SetBool("isGrounded", playerJump.GetIsGrounded());
	}
}