using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Animation goes in here. Maybe refactor someday. Put animation elsewhere
[RequireComponent(typeof(Animator))]
public class ButtonPress : MonoBehaviour
{
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player") || collider.gameObject.layer == LayerMask.NameToLayer("Attack"))
        {
            
            animator.SetBool("isPressed", true);
            GetComponent<IButton>().ActivateButton();
        }
        
    }
}
