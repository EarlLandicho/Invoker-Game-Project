using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField] private GameObject DeathAnimationObject;
    [SerializeField] private float comboBarIncreaseAmount = 5;

    private bool isFromSpawner;
    private ComboBar comboBar;

    private new void Awake()
    {
        base.Awake();
        comboBar = FindObjectOfType<ComboBar>();
    }

    public void SetisFromSpawner(bool isFromSpawner)
    {
        this.isFromSpawner = isFromSpawner;
    }

    protected override void Die()
    {
        comboBar.IncreaseComboBarLevel(comboBarIncreaseAmount);

        Instantiate(DeathAnimationObject, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void SelfDie()
    {
        Instantiate(DeathAnimationObject, transform.position, transform.rotation);
        Destroy(gameObject);

        

    }
}