using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ButtonPress : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player") || collider.gameObject.layer == LayerMask.NameToLayer("Attack"))
        {
            animator.SetBool("isPressed", true);
            GetComponent<IButton>().ActivateButton();
        }
    }
}