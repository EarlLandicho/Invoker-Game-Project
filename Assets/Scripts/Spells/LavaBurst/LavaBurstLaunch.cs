#region

using UnityEngine;

#endregion

public class LavaBurstLaunch : MonoBehaviour
{
	[SerializeField] private GameObject projectile;
	[SerializeField] private int numberofProjectiles;
	[SerializeField] private float projectileForce;

	private void Awake()
	{
		for (int i = 0; i < numberofProjectiles; i++)
		{
			Instantiate(projectile, transform.position, transform.rotation).GetComponent<Rigidbody2D>()
																		   .AddForce((Quaternion
																					 .AngleAxis((360 / numberofProjectiles) * i,
																								Vector3
																								   .forward)
																					 .normalized *
																					  new
																						  Vector2(projectileForce,
																								  0)));
		}
	}
}