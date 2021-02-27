using UnityEngine;

public class FireSpirit : MonoBehaviour
{
    [SerializeField] private float impactDamage = 0;
    [SerializeField] private GameObject explosionAnimation;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            collider.gameObject.GetComponent<StatusEffect>().BecomeBurned();
            collider.gameObject.GetComponent<IHealth>().TakeDamage(impactDamage);
            Instantiate(explosionAnimation, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        if (collider.gameObject.layer == LayerMask.NameToLayer("Enemy Projectile"))
        {
            Instantiate(explosionAnimation, transform.position, transform.rotation);
            Destroy(collider.gameObject);
        }
    }
}