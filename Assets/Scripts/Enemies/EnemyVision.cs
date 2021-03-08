#region

using UnityEngine;

#endregion

//Must be in a child gameobject of an enemy!
[RequireComponent(typeof(Collider2D))]
public class EnemyVision : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.CompareTag("Player"))
		{
			transform.parent.GetComponent<IReactToPlayerSeen>().ReactToPlayerSeen(collider.gameObject);
		}
	}

	private void OnTriggerExit2D(Collider2D collider)
	{
		if (collider.gameObject.CompareTag("Player"))
		{
			transform.parent.GetComponent<IReactToPlayerSeen>().ReactToPlayerNoLongerSeen();
		}
	}
}