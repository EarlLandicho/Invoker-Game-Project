#region

using UnityEngine;

#endregion

public class DemonKnightAttackDestroy : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.layer == LayerMask.NameToLayer("Player")
		 || collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
		{
			Destroy(gameObject);
		}
	}
}