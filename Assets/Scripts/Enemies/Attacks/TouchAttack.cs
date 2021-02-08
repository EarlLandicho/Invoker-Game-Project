using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchAttack : EnemyAttack
{
    [SerializeField] private float explosionRadius;

    private Animator animator;



    new void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            animator.SetTrigger("attack");
        }
    }

    // Called by Animator
    public void Explode()
    {
        Collider2D player = Physics2D.OverlapCircle(transform.position, explosionRadius, 1 << LayerMask.NameToLayer("Player"));
        
        if(player != null)
        {
            player.gameObject.GetComponent<IHealth>().TakeDamage(damage);
        }


    }

    // Called by Animator
    public void DestroyThis()
    {
        Destroy(gameObject);
    }




    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

}
