using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineDamage : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private Vector2 size = new Vector2(0, 0);

    void Awake()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Collider2D[] enemies = Physics2D.OverlapBoxAll((Vector2)transform.position, size, 0, 1 << LayerMask.NameToLayer("Enemy"));
            foreach (Collider2D enemy in enemies)
            {
                enemy.gameObject.GetComponent<IHealth>().TakeDamage(damage);
            }
        }
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube((Vector2)transform.position, size);
    }


}
