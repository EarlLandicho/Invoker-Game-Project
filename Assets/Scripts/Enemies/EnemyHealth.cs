using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField] private GameObject DeathAnimationObject;

    new void Awake()
    {
        base.Awake();
    }


    protected override void Die()
    {
        Instantiate(DeathAnimationObject, transform.position, transform.rotation);
        Destroy(gameObject);
    }

}