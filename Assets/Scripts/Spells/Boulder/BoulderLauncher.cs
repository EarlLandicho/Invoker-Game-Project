using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderLauncher : MonoBehaviour
{
	[SerializeField] private GameObject boulder;
	
	[SerializeField] private float randomYForHorizontal;
	[SerializeField] private float randomXForVertical;

	private ComboBar comboBar;

	private void Awake()
	{
		comboBar = GameObject.Find("GameManager").GetComponent<ComboBar>();
	}

	private void Start()
	{
		if (comboBar.GetComboBarStage() == 4)
		{
			GameObject currentobj = Instantiate(boulder, transform.position, transform.rotation);
			currentobj.GetComponent<BoulderLaunch>().AddToUpwardForce(randomYForHorizontal);
			currentobj.GetComponent<BoulderLaunch>().AddToSideForce(randomXForVertical);
			
			currentobj = Instantiate(boulder, transform.position, transform.rotation);
			currentobj.GetComponent<BoulderLaunch>().AddToUpwardForce(-randomYForHorizontal);
			currentobj.GetComponent<BoulderLaunch>().AddToSideForce(-randomXForVertical);
		}
		
			
		Instantiate(boulder, transform.position, transform.rotation);
		
		
		Destroy(gameObject);
	}
	
}
