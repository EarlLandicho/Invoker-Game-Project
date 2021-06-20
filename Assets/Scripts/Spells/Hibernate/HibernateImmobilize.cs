#region

using UnityEngine;

#endregion

public class HibernateImmobilize : MonoBehaviour
{
	[SerializeField] private GameObject hibernateReleaseSprite;
	private Animator animator;
	private IHealth playerHealth;
	private PlayerMovement playerMovement;
	private StatusEffect statusEffect;

	private void Awake()
	{
		playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
		playerHealth = GameObject.Find("Player").GetComponent<IHealth>();
		statusEffect = GameObject.Find("Player").GetComponent<StatusEffect>();
		animator = GameObject.Find("Player").GetComponent<Animator>();
	}

	private void Start()
	{
		playerHealth.SetIsInvulnerable(true);
		playerMovement.SetLockXMovement(true);
		playerMovement.SetisHibernating(true);
		statusEffect.SetIsImmuneToStun(true);
		statusEffect.Dispel();
		animator.enabled = false;
	}

	private void OnDestroy()
	{
		Instantiate(hibernateReleaseSprite, transform.position, transform.rotation);
		playerHealth.SetIsInvulnerable(false);
		playerMovement.SetLockXMovement(false);
		statusEffect.SetIsImmuneToStun(false);
		playerMovement.SetisHibernating(false);
		animator.enabled = true;
	}
}