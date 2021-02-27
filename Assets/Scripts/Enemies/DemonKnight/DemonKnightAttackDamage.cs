using UnityEngine;

public class DemonKnightAttackDamage : MonoBehaviour
{
    [SerializeField] private float damage = 0;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collider.gameObject.GetComponent<IHealth>().TakeDamage(damage);

            if (collider.gameObject.GetComponent<PlayerHealth>() != null)
            {
                //have enemies be damaged here by a percent
            }
        }
    }
}