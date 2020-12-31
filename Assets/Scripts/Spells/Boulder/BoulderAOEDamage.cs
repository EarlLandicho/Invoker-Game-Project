using UnityEngine;

public class BoulderAOEDamage : MonoBehaviour
{
    [SerializeField] private float damage = 0;
    [SerializeField] private float radiusRange = 0;

    private void Awake()
    {
        transform.parent.GetComponent<BoulderDestroy>().BoulderDestroyed += DealAOEDamage;
    }

    private void DealAOEDamage()
    {
        //need to do bit shift for the last parameter to work
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, radiusRange,
            1 << LayerMask.NameToLayer("Enemy"));
        foreach (Collider2D enemy in enemies)
        {
            enemy.gameObject.GetComponent<IHealth>().TakeDamage(damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radiusRange);
    }
}