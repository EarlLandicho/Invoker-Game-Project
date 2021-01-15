using UnityEngine;

public class FireSpirit : MonoBehaviour
{
    [SerializeField] private float impactDamage = 0;
    private float durationTemp;




    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            collider.gameObject.GetComponent<StatusEffect>().BecomeBurned();
            collider.gameObject.GetComponent<IHealth>().TakeDamage(impactDamage);
            Destroy(gameObject);
        }

        if (collider.gameObject.layer == LayerMask.NameToLayer("Enemy Projectile"))
        {
            Destroy(collider.gameObject);
        }
    }
}