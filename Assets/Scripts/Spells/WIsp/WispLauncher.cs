using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WispLauncher : MonoBehaviour
{
	[SerializeField] private GameObject wisp;
	[SerializeField] private GameObject comboBarWisp;

	private ComboBar comboBar;

	private void Awake()
	{

		comboBar = GameObject.Find("GameManager").GetComponent<ComboBar>();
	}

	private void Start()
	{
		Instantiate(wisp, transform.position, transform.rotation);

		if (comboBar.GetComboBarStage() == 4)
		{
			Instantiate(comboBarWisp, transform.position, transform.rotation);
		}
		
		Destroy(gameObject);
	}
}
