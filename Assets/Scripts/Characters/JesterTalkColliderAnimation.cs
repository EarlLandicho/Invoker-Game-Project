using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JesterTalkColliderAnimation : MonoBehaviour
{

    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    { 
        if(collider.gameObject.CompareTag("Player"))
        {
            animator.SetBool("isTalking", true);
        }
    
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            animator.SetBool("isTalking", false);
        }

    }

}
