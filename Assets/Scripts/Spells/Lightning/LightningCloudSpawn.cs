using System.Collections;
using UnityEngine;

public class LightningCloudSpawn : MonoBehaviour
{
    [SerializeField] private float damage = 0;
    [SerializeField] private float delayTime = 0;
    [SerializeField] private Vector2 centerOffSet = new Vector2(0, 0);
    [SerializeField] private Vector2 size = new Vector2(0, 0);

    private void Start()
    {
        //play animation while this is delaying. delayTime can be linked to animation duration
        StartCoroutine("WaitAndThenStrike");
    }

    private IEnumerator WaitAndThenStrike()
    {
        yield return new WaitForSeconds(delayTime);
        Collider2D[] enemies = Physics2D.OverlapBoxAll((Vector2)transform.position + centerOffSet, size, 0, 1 << LayerMask.NameToLayer("Enemy"));
        foreach (Collider2D enemy in enemies)
        {
            enemy.gameObject.GetComponent<IHealth>().TakeDamage(damage);
            enemy.gameObject.GetComponent<IStatusEffect>().BecomeStunned();
        }

        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube((Vector2)transform.position + centerOffSet, size);
    }
}