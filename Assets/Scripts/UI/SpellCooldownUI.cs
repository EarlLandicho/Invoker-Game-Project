#region

using UnityEngine;
using UnityEngine.UI;

#endregion

public class SpellCooldownUI : MonoBehaviour
{
	[SerializeField] private float alphaValue;
	[SerializeField] private GameObject S_spell;
	[SerializeField] private GameObject L_spell;

	private Image S_fill,
				  S_image,
				  L_fill,
				  L_image;

	private SpiritCast spiritcast;

	private void Awake()
	{
		spiritcast = GameObject.Find("Spirits").GetComponent<SpiritCast>();
	}

	private void Start()
	{
		S_fill = S_spell.transform.GetChild(0).GetComponent<Image>();
		S_image = S_spell.transform.GetChild(1).GetComponent<Image>();
		
		L_fill = L_spell.transform.GetChild(0).GetComponent<Image>();
		L_image = L_spell.transform.GetChild(1).GetComponent<Image>();
	}

	private void LateUpdate()
	{
		S_fill.fillAmount = (spiritcast.GetS_cooldown() - spiritcast.GetS_timer()) / spiritcast.GetS_cooldown();
		if (spiritcast.GetS_isOffCooldown())
		{
			S_fill.enabled = false;
			var colorTemp = S_image.color;
			colorTemp.a = alphaValue;
			S_image.color = colorTemp;
		}
		else
		{
			S_fill.enabled = true;
			var colorTemp = S_image.color;
			colorTemp.a = 1f;
			S_image.color = colorTemp;
		}
		
		L_fill.fillAmount = (spiritcast.GetL_cooldown() - spiritcast.GetL_timer()) / spiritcast.GetL_cooldown();
		if (spiritcast.GetL_isOffCooldown())
		{
			L_fill.enabled = false;
			var colorTemp = L_image.color;
			colorTemp.a = alphaValue;
			L_image.color = colorTemp;
		}
		else
		{
			L_fill.enabled = true;
			var colorTemp = L_image.color;
			colorTemp.a = 1f;
			L_image.color = colorTemp;
		}
		
		
	}
}