using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class WingsSummonExplosion : MonoBehaviour
{
	[SerializeField] private GameObject explosion;
	[SerializeField] private float summonTime;

	private ComboBar comboBar;

	private void Awake()
	{
		comboBar = GameObject.Find("GameManager").GetComponent<ComboBar>();
	}

	private void Start()
	{

		if (comboBar.GetComboBarStage() == 4)
		{
			InvokeRepeating("SpawnExplosion", 0, summonTime);
		}
	}

	[UsedImplicitly]
	private void SpawnExplosion()
	{
		Instantiate(explosion, transform.position, transform.rotation);
	}
}
