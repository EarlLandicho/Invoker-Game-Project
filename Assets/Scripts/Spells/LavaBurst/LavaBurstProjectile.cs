using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaBurstProjectile : MonoBehaviour
{
    [SerializeField] private float damage = 0;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            col.gameObject.GetComponent<IHealth>().TakeDamage(damage);
            col.gameObject.GetComponent<StatusEffect>().BecomeBurned();
        }

        if (col.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Destroy(gameObject);
        }
    }






}
