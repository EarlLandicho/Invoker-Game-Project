using UnityEngine;

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

    //;) get fugged nerd :)
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            animator.SetBool("isTalking", false);
        }
    }
}