#region

using UnityEngine;

#endregion

public class FireSpirit : MonoBehaviour
{
	[SerializeField] private float impactDamage;
	[SerializeField] private GameObject explosionAnimation;

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
		{
			collider.gameObject.GetComponent<StatusEffect>().BecomeBurned();
			collider.gameObject.GetComponent<IHealth>().TakeDamage(impactDamage);
			Instantiate(explosionAnimation, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}
}