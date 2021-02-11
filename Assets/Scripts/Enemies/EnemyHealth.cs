using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField] private GameObject DeathAnimationObject;
    [SerializeField] private float comboBarIncreaseAmount = 5;

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
        AddToComboBar();

        if (isFromSpawner)
        {
            EnemySpawner.numberOfEnemiesSpawned--;
        }

        Instantiate(DeathAnimationObject, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void SelfDie()
    {
        if (isFromSpawner)
        {
            EnemySpawner.numberOfEnemiesSpawned--;
        }

        Instantiate(DeathAnimationObject, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void AddToComboBar()
    {
        ComboBar.currentBarLevel += comboBarIncreaseAmount;
    }


}