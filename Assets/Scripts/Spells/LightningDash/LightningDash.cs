#region

using System;
using UnityEngine;

#endregion

public class LightningDash : MonoBehaviour
{
	[SerializeField] private float damage = 10;
	[SerializeField] private float comboBarAddedDamage;
	[SerializeField] private float dashDistance;
	[SerializeField] private float wallImpactCushion = .1f;
	[SerializeField] private float yHitboxSize = .1f;
	[SerializeField] private GameObject lightningDashAnimation;
	private Vector3 endingPosition;
	private MovementFlip movementFlip;
	private Rigidbody2D playerRigidBody;
	private Transform playerTransform;
	private Vector3 startingPosition;
	private float xHitboxSize;
	
	private ComboBar comboBar;
	private float damageTemp;

	private void Awake()
	{
		playerTransform = GameObject.Find("Player").GetComponent<Transform>();
		movementFlip = GameObject.Find("Player").GetComponent<MovementFlip>();
		playerRigidBody = GameObject.Find("Player").GetComponent<Rigidbody2D>();
		startingPosition = playerTransform.transform.position;
		
		comboBar = GameObject.Find("GameManager").GetComponent<ComboBar>();
		
		
	}

	private void Start()
	{
		FindTeleportPosition();
		DealDamageInPath();
		Instantiate(lightningDashAnimation, transform.position, transform.rotation);
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireCube(new Vector3(startingPosition.x + xHitboxSize / 2f, transform.position.y),
							new Vector3(Mathf.Abs(xHitboxSize), yHitboxSize));
	}

	private void FindTeleportPosition()
	{
		if (!movementFlip.GetIsFacingRight())
		{
			dashDistance = -dashDistance;
			wallImpactCushion = -wallImpactCushion;
		}

		RaycastHit2D hit = Physics2D.CircleCast(startingPosition, .01f,
												movementFlip.GetIsFacingRight()
													? playerTransform.transform.right
													: -playerTransform.transform.right,
												dashDistance, 1 << LayerMask.NameToLayer("Ground"));
		if (hit.collider == null)
		{
			playerTransform.transform.position = startingPosition + new Vector3(dashDistance + -wallImpactCushion, 0);
		}
		else
		{
			playerTransform.transform.position = hit.point + new Vector2(-wallImpactCushion, 0);
		}

		playerRigidBody.velocity = new Vector2(0, 0);
		endingPosition = playerTransform.transform.position;
		Destroy(gameObject, 1f);
	}

	private void DealDamageInPath()
	{
		xHitboxSize = endingPosition.x - startingPosition.x;
		Collider2D[] enemies = Physics2D.OverlapBoxAll(new Vector2(startingPosition.x + xHitboxSize / 2f, transform.position.y),
													   new Vector2(Mathf.Abs(xHitboxSize), yHitboxSize), 0,
													   1 << LayerMask.NameToLayer("Enemy"));
		if (enemies.Length > 0)
		{
			foreach (Collider2D enemyCol in enemies)
			{
				ComboBarCheck();
				enemyCol.gameObject.GetComponent<IHealth>().TakeDamage(damageTemp);
				
				if (comboBar.GetComboBarStage() == 4)
				{
					enemyCol.gameObject.GetComponent<StatusEffect>().BecomeStunned();
				}
			}
		}
	}
	
	private void ComboBarCheck()
	{
		switch (comboBar.GetComboBarStage())
		{
			case 1:
				damageTemp = damage;
				break;
			case 2:
				damageTemp = damage + comboBarAddedDamage;
				break;
			case 3:
			case 4:
				damageTemp = damage + 2 * comboBarAddedDamage;
				break;
		}
	}
}