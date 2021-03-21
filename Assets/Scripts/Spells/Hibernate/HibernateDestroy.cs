#region

using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

#endregion

public class HibernateDestroy : MonoBehaviour
{
	[SerializeField] private float duration;
	[SerializeField] private float comboBarAddedDuration;
	[SerializeField] private float comboBarHealing;
	[SerializeField] private GameObject[] shards;
	[SerializeField] private int numberOfShards;
	[SerializeField] private float shardsLaunchForce;

	private ComboBar comboBar;
	private Health playerHealth;
	

	private void Awake()
	{
		comboBar = GameObject.Find("GameManager").GetComponent<ComboBar>();
		playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
	}

	private void Start()
	{
		ComboBarCheck();
		StartCoroutine("HibernateDuration");
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			StopAllCoroutines();
			Destroy(gameObject);
		}
	}

	private void OnDestroy()
	{
		for (int i = 0; i < numberOfShards; i++)
		{
			int randomShardNum = Random.Range(0, shards.Length);
			float randomForceAmount = Random.Range(shardsLaunchForce - 70, shardsLaunchForce + 70);
			Instantiate(shards[randomShardNum], transform.position, transform.rotation).GetComponent<Rigidbody2D>()
																					   .AddForce((Quaternion.AngleAxis((Random.Range(0, 180)), 
																													   Vector3.forward).normalized * new Vector2(randomForceAmount, 0)));
		}
	}

	private IEnumerator HibernateDuration()
	{
		yield return new WaitForSeconds(duration);
		Destroy(gameObject);
	}

	private void ComboBarCheck()
	{
		switch (comboBar.GetComboBarStage())
		{
			case 2:
				duration += comboBarAddedDuration;
				break;
			case 3:
				duration += 2 * comboBarAddedDuration;
				break;
			case 4:
				playerHealth.TakeHealing(comboBarHealing);
				break;
			default:
				return;
		}
	}
}