#region

using System;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

#endregion

public class IcicleLauncher : MonoBehaviour
{
	[SerializeField] private GameObject icicleProjectile;
	[SerializeField] private float launchDelay;
	[SerializeField] private int numberOfProjectiles;
	[SerializeField] private float randomLaunchPositionRadius;
	[SerializeField] private int comboBarExtraProjectiles;

	private ComboBar comboBar;
	
	private float angle;

	private void Awake()
	{
		comboBar = GameObject.Find("GameManager").GetComponent<ComboBar>();
		
	}

	private void Start()
	{
		if (Input.GetKey(KeyCode.W))
		{
			angle = 90;
		}
		else if (Input.GetKey(KeyCode.S))
		{
			angle = -90;
		}

		if (comboBar.GetComboBarStage() == 4)
		{
			for (int i = 0; i < comboBarExtraProjectiles; i++)
			{
				Instantiate(icicleProjectile, transform.position, Quaternion.identity).GetComponent<IcicleLaunch>().LaunchRadial((360 / comboBarExtraProjectiles) * i);
			}	
		}
		InvokeRepeating("Launch", 0f, launchDelay);
	}

	private void Launch()
	{
		numberOfProjectiles--;
		Instantiate(icicleProjectile, transform.position +
					new Vector3(Random.Range(-randomLaunchPositionRadius, randomLaunchPositionRadius), 
								Random.Range(-randomLaunchPositionRadius, randomLaunchPositionRadius) + 0.1f), 
					transform.rotation)
					.GetComponent<IcicleLaunch>().Launch(angle);
		
		if (numberOfProjectiles <= 0)
		{
			CancelInvoke();
			Destroy(gameObject);
		}
	}
}