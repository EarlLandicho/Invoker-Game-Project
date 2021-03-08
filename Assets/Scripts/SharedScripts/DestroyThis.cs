#region

using System.Collections;
using UnityEngine;

#endregion

public class DestroyThis : MonoBehaviour
{
	[SerializeField] private bool isTimedDestroy;
	[SerializeField] private float timedDestroyTime;

	private void Update()
	{
		if (isTimedDestroy)
		{
			isTimedDestroy = false;
			StartCoroutine("DestroyTimedObject");
		}
	}

	// Called in Animator
	public void DestroyThisObject()
	{
		Destroy(gameObject);
	}

	private IEnumerator DestroyTimedObject()
	{
		yield return new WaitForSeconds(timedDestroyTime);
		Destroy(gameObject);
	}
}