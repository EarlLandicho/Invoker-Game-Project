using UnityEngine;

//Must be in a child gameobject of an enemy!
[RequireComponent(typeof(Collider2D))]
public class EnemyAttackRange : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            transform.parent.GetComponent<IEnemyAttack>().Attack(collider.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            transform.parent.GetComponent<IEnemyAttack>().OutOfAttackRange();
        }
    }
}