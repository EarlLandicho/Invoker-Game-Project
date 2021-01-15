using UnityEngine;

public class PoisonExplosion : MonoBehaviour
{
    [SerializeField] private float explosionRadius;
    [SerializeField] private float impactDamage;
    [SerializeField] private float cloudPoisonCheck;
    [SerializeField] private float poisonDuration;

    private float cloudPoisonCheckTimer;

    

    private void Awake()
    {
        cloudPoisonCheckTimer = cloudPoisonCheck;

        
        Destroy(gameObject, poisonDuration);
    }

    void Update()
    {
        if(cloudPoisonCheckTimer > 0)
        {
            cloudPoisonCheckTimer -= Time.deltaTime;
        }
        else
        {
            cloudPoisonCheckTimer = cloudPoisonCheck;
            PoisonArea();
        }
    }

    private void PoisonArea()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, explosionRadius, 1 << LayerMask.NameToLayer("Enemy"));
        if (enemies.Length > 0)
        {
            foreach (Collider2D enemyCol in enemies)
            {
                enemyCol.gameObject.GetComponent<IHealth>().TakeDamage(impactDamage);
                enemyCol.gameObject.GetComponent<StatusEffect>().BecomePoisoned();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}