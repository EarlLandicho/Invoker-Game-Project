#region

using System;
using System.Collections;
using UnityEngine;

#endregion

public class LavaBurstLaunch : MonoBehaviour
{
	[SerializeField] private GameObject projectile;
	[SerializeField] private int numberofProjectiles;
	[SerializeField] private float projectileForce;
	[SerializeField] private float comboBarSecondExplosionDelayTime;

	
	private ComboBar comboBar;

	private void Awake()
	{
		comboBar = GameObject.Find("GameManager").GetComponent<ComboBar>();
		
		
	}

	private void Start()
	{
		if (comboBar.GetComboBarStage() == 4)
		{
			Invoke("SecondBurst", comboBarSecondExplosionDelayTime);
		}
		
		for (int i = 0; i < numberofProjectiles; i++)
		{
			Instantiate(projectile, transform.position, transform.rotation).GetComponent<Rigidbody2D>()
																		   .AddForce((Quaternion.AngleAxis((360 / numberofProjectiles) * i, Vector3.forward)
																								.normalized *new Vector2(projectileForce, 0)));
		}
	}

	private void SecondBurst()
	{
		for (int i = 0; i < numberofProjectiles; i++)
		{
			Instantiate(projectile, transform.position, transform.rotation).GetComponent<Rigidbody2D>()
																		   .AddForce((Quaternion.AngleAxis((360 / numberofProjectiles) * i, Vector3.forward)
																								.normalized *new Vector2(projectileForce, 0)));
		}
	}
}