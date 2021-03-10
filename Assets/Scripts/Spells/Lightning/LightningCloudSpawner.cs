#region

using UnityEngine;

#endregion

public class LightningCloudSpawner : MonoBehaviour
{
	[SerializeField] private GameObject lightningStrike;
	[SerializeField] private float comboBarExtraLightningDelay;
	[SerializeField] private int comboBarExtraLightningStrike;

	private ComboBar comboBar;
	private int extraLightningStrikeCount;

	private void Awake()
	{
		comboBar = GameObject.Find("GameManager").GetComponent<ComboBar>();
	}

	private void Start()
	{
		Instantiate(lightningStrike, transform.position, transform.rotation);

		if (comboBar.GetComboBarStage() == 4)
		{
			InvokeRepeating("Strike", comboBarExtraLightningDelay, comboBarExtraLightningDelay);
			extraLightningStrikeCount = 0;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	private void Strike()
	{
		Instantiate(lightningStrike, transform.position, transform.rotation);
		extraLightningStrikeCount++;
		if (extraLightningStrikeCount >= comboBarExtraLightningStrike)
		{
			Destroy(gameObject);
		}
	}
}