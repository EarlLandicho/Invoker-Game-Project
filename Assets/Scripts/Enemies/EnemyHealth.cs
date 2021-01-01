using UnityEngine;

public class EnemyHealth : MonoBehaviour, IHealth
{
    [SerializeField] private float maxHealth = 0;

    private float currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage, bool isStatusEffectDamage = false)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }

        FlashWhenDamaged();
    }

    public void FlashWhenDamaged()
    {
        if (GetComponent<FlashWhenDamaged>() != null)
        {
            GetComponent<FlashWhenDamaged>().FlashSprite();
        }
    }

    //unused for now
    public void TakeHealing(float heal)
    {
        currentHealth += heal;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void SetIsInvulnerable(bool isInvulnerable)
    {

    }

    private void Die()
    {
        Destroy(gameObject);
    }
}