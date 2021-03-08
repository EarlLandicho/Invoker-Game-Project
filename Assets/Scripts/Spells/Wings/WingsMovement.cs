#region

using UnityEngine;

#endregion

public class WingsMovement : MonoBehaviour
{
	public static float flightDurationTemp;
	private static WingsMovement instance;
	[SerializeField] private float flightDuration;
	[SerializeField] private float flightSpeedFactor;
	private PlayerMovement playerMovement;

	private void Awake()
	{
		//Singleton
		if (instance != null)
		{
			//reset duration here
			flightDurationTemp = flightDuration;
			Destroy(gameObject);
			return;
		}

		instance = this;
		playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
		playerMovement.SetMovementSpeedByFactor(flightSpeedFactor, true);
		playerMovement.SetIsFlying(true);
		flightDurationTemp = flightDuration;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			CancelFlight();
			Destroy(gameObject);
		}

		if (flightDurationTemp > 0)
		{
			flightDurationTemp -= Time.deltaTime;
		}
		else
		{
			CancelFlight();
			Destroy(gameObject);
		}
	}

	public void CancelFlight()
	{
		playerMovement.SetMovementSpeedByFactor(flightSpeedFactor, false);
		playerMovement.SetIsFlying(false);
	}
}