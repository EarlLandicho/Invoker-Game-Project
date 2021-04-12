#region

using UnityEngine;

#endregion

[RequireComponent(typeof(CompositeCollider2D))]
public class TileJumpDown : MonoBehaviour
{
	private readonly float reverseCollisionTimer = .1f;
	private CompositeCollider2D compositeCollider;
	private PlayerMovement playerMovement;
	private PlayerJump playerJump;
	private StatusEffect playerStatusEffect;
	private float reverseCollisionTimerTemp;
	private bool reverseDelay;

	private void Awake()
	{
		compositeCollider = GetComponent<CompositeCollider2D>();
		reverseCollisionTimerTemp = reverseCollisionTimer;
		playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
		playerStatusEffect = GameObject.Find("Player").GetComponent<StatusEffect>();
		playerJump = GameObject.Find("Player").GetComponent<PlayerJump>();
	}

	private void Update()
	{
		if (Input.GetKey(KeyCode.S))
		{
			if (!playerJump.GetIsGrounded())
			{
				if (!playerMovement.GetIsHibernating() && !playerStatusEffect.GetIsStunned())
				{
					Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Ledge"));
					compositeCollider.usedByEffector = false;
				}
			}
		}
		else if (Input.GetKeyUp(KeyCode.S))
		{
			reverseDelay = true;
		}

		if (reverseDelay)
		{
			if (reverseCollisionTimerTemp > 0)
			{
				reverseCollisionTimerTemp -= Time.deltaTime;
			}
			else
			{
				reverseCollisionTimerTemp = reverseCollisionTimer;
				Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Ledge"), false);
				compositeCollider.usedByEffector = true;
				reverseDelay = false;
			}
		}
	}
}