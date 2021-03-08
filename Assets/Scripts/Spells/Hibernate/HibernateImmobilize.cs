#region

using UnityEngine;

#endregion

public class HibernateImmobilize : MonoBehaviour
{
	[SerializeField] private GameObject hibernateRealeaseSprite;
	private IHealth playerHealth;
	private PlayerMovement playerMovement;

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
		Instantiate(hibernateRealeaseSprite, transform.position, transform.rotation);
		playerHealth.SetIsInvulnerable(false);
		playerMovement.SetLockXMovement(false);
		playerMovement.SetisHibernating(false);
	}
}