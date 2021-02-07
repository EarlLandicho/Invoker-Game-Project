using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyProjectile : MonoBehaviour
{
    private float projectileSpeed;
    private float damage;
    private Vector2 playerDirection;
    private Animator animator;



    protected Rigidbody2D projectileRigidbody;

    private void Awake()
    {
        projectileRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    public void SetDamage(float damage)
    {
        this.damage = damage;
    }

    public void SetPlayerDirection(Vector2 playerDirection)
    {
        this.playerDirection = playerDirection;
    }

    public void SetProjectileSpeed(float projectileSpeed)
    {
        this.projectileSpeed = projectileSpeed;
    }

    public void Launch()
    {
        projectileRigidbody.velocity = projectileSpeed * playerDirection;
    }


    // Called by animator
    public void DestroyThisObject()
    {
        Destroy(gameObject);
    }

    // Called by animator
    public void StopMovement()
    {
        projectileRigidbody.velocity = new Vector2(0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == LayerMask.NameToLayer("Player") ||
            collider.gameObject.layer == LayerMask.NameToLayer("Ally"))
        {
            collider.GetComponent<IHealth>().TakeDamage(damage);
            animator.SetTrigger("hasHitSomething");
        }
        else if(collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            animator.SetTrigger("hasHitSomething");
        }
    }



}
