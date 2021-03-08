#region

using UnityEngine;

#endregion

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class GoblinAnimator : MonoBehaviour
{
	private Animator animator;
	private Rigidbody2D rb;

	private void Awake()
	{
		animator = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		animator.SetFloat("velocity", Mathf.Abs(rb.velocity.x));
	}
}