#region

using System;
using UnityEngine;

#endregion

public class FireSpiritRotateAroundPlayer : MonoBehaviour
{
	[SerializeField] private GameObject fireRing;
	[SerializeField] private float spiritRotationRadius;
	[SerializeField] private float spiritRotateSpeed;

	
	private GameObject fireRing1;
	private GameObject fireRing2;
	private GameObject fireRing3;
	private float oneThirdOfACircle;
	private Transform playerTransform;
	private float spiritRotationAngle;
	private float twoThirdsOfACircle;
	private float addedAngle;

	private void Awake()
	{
		playerTransform = GameObject.Find("Player").GetComponent<Transform>();
		
	}

	private void Start()
	{
		fireRing1 = Instantiate(fireRing, transform);
		fireRing2 = Instantiate(fireRing, transform);
		fireRing3 = Instantiate(fireRing, transform);
		oneThirdOfACircle = 4 * Mathf.PI / 6;
		twoThirdsOfACircle = 8 * Mathf.PI / 6;
	}

	private void Update()
	{
		RotateSpiritAroundPlayer();
	}

	public void AddToSpiritRotationRadius(float value)
	{
		spiritRotationRadius += value;
	}

	public void AddToAngle(float value)
	{
		addedAngle += value;
	}
	

	private void RotateSpiritAroundPlayer()
	{
		spiritRotationAngle += spiritRotateSpeed * Time.deltaTime;
		if (fireRing1 != null)
		{
			fireRing1.transform.position = playerTransform.position
										 + new Vector3(Mathf.Sin(spiritRotationAngle + addedAngle),
													   Mathf.Cos(spiritRotationAngle + addedAngle),
													   0) 
										 * spiritRotationRadius;
		}

		if (fireRing2 != null)
		{
			fireRing2.transform.position = playerTransform.position
										 + new Vector3(Mathf.Sin(spiritRotationAngle + oneThirdOfACircle + addedAngle),
													   Mathf.Cos(spiritRotationAngle + oneThirdOfACircle + addedAngle),
													   0)
										 * spiritRotationRadius;
		}

		if (fireRing3 != null)
		{
			fireRing3.transform.position = playerTransform.position
										 + new Vector3(Mathf.Sin(spiritRotationAngle + twoThirdsOfACircle + addedAngle),
													   Mathf.Cos(spiritRotationAngle + twoThirdsOfACircle + addedAngle),
													   0)
										 * spiritRotationRadius;
		}
	}
}