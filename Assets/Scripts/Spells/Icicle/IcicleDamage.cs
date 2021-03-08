#region

using UnityEngine;

#endregion

public class IcicleDamage : MonoBehaviour
{
	[SerializeField] private float damage;
	private bool isColliding;

	private void Update()
	{
		isColliding = false;
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		//prevents multiple collisions
		if (isColliding)
		{
			return;
		}

		isColliding = true;
		if (collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
		{
			collider.gameObject.GetComponent<IHealth>().TakeDamage(damage);
		}
	}
}