using System;
using UnityEngine;

public class BoulderDestroy : MonoBehaviour
{
    //used by BuilderAOEDamage
    public event Action BoulderDestroyed = delegate { };

    [SerializeField] private GameObject explosionAnimation;


    private void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.gameObject.layer == LayerMask.NameToLayer("Enemy")
            || collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            DestroyBoulder();
        }
    }
    // OnTriggerStay is here so that it OnTriggerEnter fails to detect collision, then it will do additional checks to make sure it hits.
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Enemy")
            || collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            DestroyBoulder();
        }
    }

    private void DestroyBoulder()
    {
        BoulderDestroyed();
        Instantiate(explosionAnimation, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}