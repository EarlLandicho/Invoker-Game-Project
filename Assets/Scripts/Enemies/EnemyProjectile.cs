using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed;
    protected float damage;
    protected Vector2 playerDirection;
    protected Rigidbody2D projectileRigidbody;

    protected void Awake()
    {
        projectileRigidbody = GetComponent<Rigidbody2D>();
    }


    public void SetDamage(float damage)
    {
        this.damage = damage;
    }

    public void SetPlayerDirection(Vector2 playerDirection)
    {
        this.playerDirection = playerDirection;
    }

    public void Launch()
    {
        projectileRigidbody.velocity = projectileSpeed * playerDirection;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == LayerMask.NameToLayer("Player") ||
            collider.gameObject.layer == LayerMask.NameToLayer("Ally"))
        {
            collider.GetComponent<IHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if(collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Destroy(gameObject);
        }
    }

}
