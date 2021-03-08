#region

using System;
using UnityEngine;

#endregion

public class BoulderDestroy : MonoBehaviour
{
	[SerializeField] private GameObject explosionAnimation;

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.layer == LayerMask.NameToLayer("Enemy")
		 || collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
		{
			DestroyBoulder();
		}
	}

	// OnTriggerStay is here so that it OnTriggerEnter fails to detect collision, then it will do additional checks to make sure it hits.
	private void OnTriggerStay2D(Collider2D collider)
	{
		if (collider.gameObject.layer == LayerMask.NameToLayer("Enemy")
		 || collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
		{
			DestroyBoulder();
		}
	}

	//used by BuilderAOEDamage
	public event Action BoulderDestroyed = delegate { };

	private void DestroyBoulder()
	{
		BoulderDestroyed();
		Instantiate(explosionAnimation, transform.position, transform.rotation);
		Destroy(gameObject);
	}
}