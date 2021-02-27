using UnityEngine;

public class HibernateHeal : MonoBehaviour
{
    [SerializeField] private float healPerSec = 0;
    private IHealth playerHealth;

    //SUGGESTION: Move to StatusEffect functionality
    private void Awake()
    {
        playerHealth = GameObject.Find("Player").GetComponent<IHealth>();

        InvokeRepeating("HibernateTickHealing", 0, Constants.HealTickPerSecond);
    }

    private void HibernateTickHealing()
    {
        playerHealth.TakeHealing(healPerSec * Constants.HealTickPerSecond);
    }

    private void OnDestroy()
    {
        CancelInvoke("HibernateTickHealing");
    }
}