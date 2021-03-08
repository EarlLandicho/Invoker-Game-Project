#region

using UnityEngine;

#endregion

public class GameObjectLifetime : MonoBehaviour
{
	[SerializeField] private float lifeTime;
	private float lifeTImeTemp;

	private void Awake()
	{
		lifeTImeTemp = lifeTime;
	}

	private void Update()
	{
		if (lifeTImeTemp > 0)
		{
			lifeTImeTemp -= Time.deltaTime;
		}
		else
		{
			Destroy(gameObject);
		}
	}
}