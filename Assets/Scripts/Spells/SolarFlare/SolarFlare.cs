using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarFlare : MonoBehaviour
{
    [SerializeField] private float radius = 0;

    void Awake()
    {

        


        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, radius, 1 << LayerMask.NameToLayer("Enemy"));
        foreach (Collider2D enemy in enemies)
        {
            enemy.gameObject.GetComponent<StatusEffect>().BecomeBurned();
        }

        
        StartCoroutine("Flash");

    }

    private IEnumerator Flash()
    {
        yield return new WaitForSeconds(.1f);

        Collider2D[] projectiles = Physics2D.OverlapCircleAll(transform.position, radius, 1 << LayerMask.NameToLayer("Enemy Projectile"));
        foreach (Collider2D projectile in projectiles)
        {
            projectile.gameObject.GetComponent<EnemyProjectile>().DestroyWithAnimation();
            //Destroy(projectile.gameObject);
        }

        Destroy(gameObject);
    }

    void OnDrawGizmos()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
