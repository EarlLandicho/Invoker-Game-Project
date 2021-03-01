using UnityEngine;

public class LavaBurstProjectile : MonoBehaviour
{
    [SerializeField] private float damage = 0;

    [SerializeField] private GameObject explosionAnimation;



    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            col.gameObject.GetComponent<IHealth>().TakeDamage(damage);
            col.gameObject.GetComponent<StatusEffect>().BecomeBurned();

            Explode();
        }

        if (col.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Explode();
        }
    }

    private void Explode()
    {
        Instantiate(explosionAnimation, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}