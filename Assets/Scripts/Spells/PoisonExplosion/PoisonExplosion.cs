using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonExplosion : MonoBehaviour
{
    [SerializeField] private float explosionRadius;
    [SerializeField] private float impactDamage;

    void Awake()
    {

        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, explosionRadius, 1 << LayerMask.NameToLayer("Enemy"));
        Debug.Log(enemies.Length);
        if (enemies.Length > 0)
        {
            foreach (Collider2D enemyCol in enemies)
            {
                enemyCol.gameObject.GetComponent<IHealth>().TakeDamage(impactDamage);
                enemyCol.gameObject.GetComponent<StatusEffect>().BecomePoisoned();
            }


        }
        Destroy(gameObject, 1f);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }


}
