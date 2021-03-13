using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRingSpiritLauncher : MonoBehaviour
{
	[SerializeField] private GameObject fireSpirit;
	[SerializeField] private float comboBarRadiusAdded;

	

	private ComboBar comboBar;
	private void Awake()
	{
		comboBar = GameObject.Find("GameManager").GetComponent<ComboBar>();

		if (comboBar.GetComboBarStage() == 4)
		{
			GameObject obj = Instantiate(fireSpirit, transform.position, transform.rotation);
			obj.transform.Rotate(0, 0, 30);
			obj.GetComponent<FireSpiritRotateAroundPlayer>()
			   .AddToSpiritRotationRadius(comboBarRadiusAdded);
			obj.GetComponent<FireSpiritRotateAroundPlayer>()
			   .AddToAngle(60);
			
			GameObject obj1 = Instantiate(fireSpirit, transform.position, transform.rotation);
			obj1.transform.Rotate(0, 0, 60);
			obj1.GetComponent<FireSpiritRotateAroundPlayer>()
				.AddToSpiritRotationRadius(2 * comboBarRadiusAdded);
			obj1.GetComponent<FireSpiritRotateAroundPlayer>()
				.AddToAngle(30);
			
		}
		


		Instantiate(fireSpirit, transform.position, transform.rotation);
		
		Destroy(gameObject);
	}
	
}
