using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WispAttack : MonoBehaviour
{
    [SerializeField] private float damage = 0;
    [SerializeField] private float attackSpeed = 0;
    [SerializeField] private float lifetimeDuration = 0;
    [SerializeField] private float radius = 0;

    private float attackSpeedTemp = 0;
    void Awake()
    {
        attackSpeedTemp = attackSpeed;

        StartCoroutine("Lifetime");
        
    }

    void Update()
    {
        if (attackSpeedTemp > 0)
        {
            attackSpeedTemp -= Time.deltaTime;
        }
        else
        {
            attackSpeedTemp = attackSpeed;
            Attack();
        }


    }

    private IEnumerator Lifetime()
    {
        yield return new WaitForSeconds(lifetimeDuration);
        Destroy(gameObject);
    }

    private void Attack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, radius, 1 << LayerMask.NameToLayer("Enemy"));

        if(enemies.Length > 0)
        {
            int ranNum = Random.Range(0, enemies.Length);
            enemies[ranNum].gameObject.GetComponent<IHealth>().TakeDamage(damage);
        }

    }

    void OnDrawGizmos()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
