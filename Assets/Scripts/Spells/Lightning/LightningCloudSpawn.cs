using System.Collections;
using UnityEngine;

public class LightningCloudSpawn : MonoBehaviour
{
    [SerializeField] private float damage = 0;
    [SerializeField] private Vector2 centerOffSet = new Vector2(0, 0);
    [SerializeField] private Vector2 size = new Vector2(0, 0);
    [SerializeField] private LayerMask layerMask;
    

    private void Start()
    {
        float yOffSet = .40f;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 500f, layerMask);
        transform.position = hit.point + new Vector2(0, yOffSet);




    }

    // Called in Animator
    public void DealDamage()
    {
        Collider2D[] enemies = Physics2D.OverlapBoxAll((Vector2)transform.position + centerOffSet, size, 0, 1 << LayerMask.NameToLayer("Enemy"));
        foreach (Collider2D enemy in enemies)
        {
            enemy.gameObject.GetComponent<IHealth>().TakeDamage(damage);
            enemy.gameObject.GetComponent<StatusEffect>().BecomeStunned();
        }
    }




    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube((Vector2)transform.position + centerOffSet, size);
    }
}