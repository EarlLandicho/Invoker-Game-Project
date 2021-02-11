using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField] private GameObject DeathAnimationObject;

    private bool isFromSpawner;

    new void Awake()
    {
        base.Awake();
    }

    public void SetisFromSpawner(bool isFromSpawner)
    {
        this.isFromSpawner = isFromSpawner;
    }

    protected override void Die()
    {
        if (isFromSpawner)
        {
            EnemySpawner.numberOfEnemiesSpawned--;
        }

        Instantiate(DeathAnimationObject, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    

}