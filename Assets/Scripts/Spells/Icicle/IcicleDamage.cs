using UnityEngine;

public class IcicleDamage : MonoBehaviour
{
    [SerializeField] private float damage = 0;

    private bool isColliding;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //prevents multiple collisions
        if (isColliding)
        {
            return;
        }
        isColliding = true;

        if (collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            collider.gameObject.GetComponent<IHealth>().TakeDamage(damage);
            
        }
    }

    private void Update()
    {
        isColliding = false;
    }
}