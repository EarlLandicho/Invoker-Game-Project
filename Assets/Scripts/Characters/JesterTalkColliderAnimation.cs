#region

using UnityEngine;

#endregion

public class JesterTalkColliderAnimation : MonoBehaviour
{
	private Animator animator;

	private void Awake()
	{
		animator = GetComponent<Animator>();
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.CompareTag("Player"))
		{
			animator.SetBool("isTalking", true);
		}
	}

	private void OnTriggerExit2D(Collider2D collider)
	{
		if (collider.gameObject.CompareTag("Player"))
		{
			animator.SetBool("isTalking", false);
		}
	}
}