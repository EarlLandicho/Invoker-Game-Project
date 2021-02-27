using UnityEngine;

public class HibernateImmobilize : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private IHealth playerHealth;

    private void Awake()
    {
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        playerHealth = GameObject.Find("Player").GetComponent<IHealth>();

        playerHealth.SetIsInvulnerable(true);
        playerMovement.SetLockXMovement(true);
        playerMovement.SetisHibernating(true);
    }

    private void OnDestroy()
    {
        playerHealth.SetIsInvulnerable(false);
        playerMovement.SetLockXMovement(false);
        playerMovement.SetisHibernating(false);
    }
}