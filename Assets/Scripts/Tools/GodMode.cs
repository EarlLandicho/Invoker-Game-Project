#region

using UnityEngine;

#endregion

public class GodMode : MonoBehaviour
{
	private bool isGodMode;
	private PlayerHealth playerHealth;
	private SpiritArrayManager spiritArrayManager;
	private SpiritCast spiritCast;
	private SpriteRenderer spriteRenderer;

	private void Awake()
	{
		GetComponent<InputTools>().GodModeActivated += ActivateGodMode;
		spriteRenderer = GameObject.Find("Player").GetComponent<SpriteRenderer>();
		playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
		spiritArrayManager = GameObject.Find("GameManager").GetComponent<SpiritArrayManager>();
		spiritCast = GameObject.Find("Spirits").GetComponent<SpiritCast>();
	}

	private void Update()
	{
		if (isGodMode)
		{
			spriteRenderer.color = Color.black;
			spiritCast.ResetAllCooldowns();
		}
	}

	private void OnDestroy()
	{
		GetComponent<InputTools>().GodModeActivated -= ActivateGodMode;
	}

	private void ActivateGodMode()
	{
		if (!isGodMode)
		{
			isGodMode = true;
			playerHealth.SetGodModeHealth(true);
			ObtainAllSpirits(true);
		}
		else
		{
			isGodMode = false;
			playerHealth.SetGodModeHealth(false);
			spriteRenderer.color = Color.white;
			ObtainAllSpirits(false);
		}
	}

	private void ObtainAllSpirits(bool isObtaining)
	{
		if (isObtaining)
		{
			spiritArrayManager.IncrementSpiritCurrentAmount();
			spiritArrayManager.IncrementSpiritCurrentAmount();
			spiritArrayManager.IncrementSpiritCurrentAmount();
		}
		else
		{
			spiritArrayManager.DecrementSpiritCurrentAmount();
			spiritArrayManager.DecrementSpiritCurrentAmount();
			spiritArrayManager.DecrementSpiritCurrentAmount();
		}
	}
}