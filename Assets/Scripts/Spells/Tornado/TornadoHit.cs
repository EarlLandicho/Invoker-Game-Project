using UnityEngine;

public class TornadoHit : MonoBehaviour
{
    [SerializeField] private float damage = 0;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            col.gameObject.GetComponent<IHealth>().TakeDamage(damage);
            col.gameObject.GetComponent<StatusEffect>().BecomeStunned();
        }

        if (col.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Destroy(gameObject);
        }
    }
}