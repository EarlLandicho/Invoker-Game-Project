using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingsAnimation : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        animator.SetFloat("velocityY", rb.velocity.y);
    }
}
