using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpirit : MonoBehaviour
{
    [SerializeField] private float impactDamage = 0;


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            collider.gameObject.GetComponent<StatusEffect>().BecomeBurned();
            collider.gameObject.GetComponent<IHealth>().TakeDamage(impactDamage);
            Destroy(gameObject);
        }
    }

}
