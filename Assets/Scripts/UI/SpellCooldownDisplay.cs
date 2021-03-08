#region

using System;
using TMPro;
using UnityEngine;

#endregion

public class SpellCooldownDisplay : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI S_cooldownText,
											 L_cooldownText,
											 G__cooldownText,
											 SS_cooldownText,
											 LL_cooldownText,
											 GG_cooldownText,
											 SL_cooldownText,
											 SG_cooldownText,
											 LG_cooldownText,
											 SSS_cooldownText,
											 LLL_cooldownText,
											 GGG_cooldownText,
											 SSL_cooldownText,
											 SSG_cooldownText,
											 SLL_cooldownText,
											 SGG_cooldownText,
											 LLG_cooldownText,
											 LGG_cooldownText,
											 SLG_cooldownText;

	private SpiritCast spiritCast;

	//[SerializeField] private TextMeshProUGUI icicleCd,  boulderCd;

	private void Start()
	{
		spiritCast = GameObject.Find("Spirits").GetComponent<SpiritCast>();
	}

	private void LateUpdate()
	{
		UpdateCooldownsUI();
	}

	private void UpdateCooldownsUI()
	{
		if (spiritCast.GetS_isOffCooldown())
		{
			S_cooldownText.text = "S\tBoulder Throw";
		}
		else
		{
			S_cooldownText.text = (Math.Truncate(spiritCast.GetS_timer() * 100) / 100).ToString();
		}

		if (spiritCast.GetL_isOffCooldown())
		{
			L_cooldownText.text = "L\tIcicle";
		}
		else
		{
			L_cooldownText.text = (Math.Truncate(spiritCast.GetL_timer() * 100) / 100).ToString();
		}

		if (spiritCast.GetG_isOffCooldown())
		{
			G__cooldownText.text = "G\tLightning";
		}
		else
		{
			G__cooldownText.text = (Math.Truncate(spiritCast.GetG_timer() * 100) / 100).ToString();
		}

		if (spiritCast.GetSS_isOffCooldown())
		{
			SS_cooldownText.text = "SS\tEarth Armor";
		}
		else
		{
			SS_cooldownText.text = (Math.Truncate(spiritCast.GetSS_timer() * 100) / 100).ToString();
		}

		if (spiritCast.GetLL_isOffCooldown())
		{
			LL_cooldownText.text = "LL\tSlow Heal";
		}
		else
		{
			LL_cooldownText.text = (Math.Truncate(spiritCast.GetLL_timer() * 100) / 100).ToString();
		}

		if (spiritCast.GetGG_isOffCooldown())
		{
			GG_cooldownText.text = "GG\tLightning Dash";
		}
		else
		{
			GG_cooldownText.text = (Math.Truncate(spiritCast.GetGG_timer() * 100) / 100).ToString();
		}

		if (spiritCast.GetSL_isOffCooldown())
		{
			SL_cooldownText.text = "SL\tGround Slam";
		}
		else
		{
			SL_cooldownText.text = (Math.Truncate(spiritCast.GetSL_timer() * 100) / 100).ToString();
		}

		if (spiritCast.GetSG_isOffCooldown())
		{
			SG_cooldownText.text = "SG\tFire Spirit";
		}
		else
		{
			SG_cooldownText.text = (Math.Truncate(spiritCast.GetSG_timer() * 100) / 100).ToString();
		}

		if (spiritCast.GetLG_isOffCooldown())
		{
			LG_cooldownText.text = "LG\tPoison Explosion";
		}
		else
		{
			LG_cooldownText.text = (Math.Truncate(spiritCast.GetLG_timer() * 100) / 100).ToString();
		}

		if (spiritCast.GetSSS_isOffCooldown())
		{
			SSS_cooldownText.text = "SSS\tMud Golem";
		}
		else
		{
			SSS_cooldownText.text = (Math.Truncate(spiritCast.GetSSS_timer() * 100) / 100).ToString();
		}

		if (spiritCast.GetLLL_isOffCooldown())
		{
			LLL_cooldownText.text = "LLL\tHibernate";
		}
		else
		{
			LLL_cooldownText.text = (Math.Truncate(spiritCast.GetLLL_timer() * 100) / 100).ToString();
		}

		if (spiritCast.GetGGG_isOffCooldown())
		{
			GGG_cooldownText.text = "GGG\tTornado";
		}
		else
		{
			GGG_cooldownText.text = (Math.Truncate(spiritCast.GetGGG_timer() * 100) / 100).ToString();
		}

		if (spiritCast.GetSSL_isOffCooldown())
		{
			SSL_cooldownText.text = "SSL\tLava Burst";
		}
		else
		{
			SSL_cooldownText.text = (Math.Truncate(spiritCast.GetSSL_timer() * 100) / 100).ToString();
		}

		if (spiritCast.GetSSG_isOffCooldown())
		{
			SSG_cooldownText.text = "SSG\tWisp";
		}
		else
		{
			SSG_cooldownText.text = (Math.Truncate(spiritCast.GetSSG_timer() * 100) / 100).ToString();
		}

		if (spiritCast.GetSLL_isOffCooldown())
		{
			SLL_cooldownText.text = "SLL\tSolar Flare";
		}
		else
		{
			SLL_cooldownText.text = (Math.Truncate(spiritCast.GetSLL_timer() * 100) / 100).ToString();
		}

		if (spiritCast.GetSGG_isOffCooldown())
		{
			SGG_cooldownText.text = "SGG\tWings";
		}
		else
		{
			SGG_cooldownText.text = (Math.Truncate(spiritCast.GetSGG_timer() * 100) / 100).ToString();
		}

		if (spiritCast.GetLLG_isOffCooldown())
		{
			LLG_cooldownText.text = "LLG\tBubble";
		}
		else
		{
			LLG_cooldownText.text = (Math.Truncate(spiritCast.GetLLG_timer() * 100) / 100).ToString();
		}

		if (spiritCast.GetLGG_isOffCooldown())
		{
			LGG_cooldownText.text = "LGG\tTrampoline";
		}
		else
		{
			LGG_cooldownText.text = (Math.Truncate(spiritCast.GetLLG_timer() * 100) / 100).ToString();
		}

		if (spiritCast.GetSLG_isOffCooldown())
		{
			SLG_cooldownText.text = "SLG\tReseter";
		}
		else
		{
			SLG_cooldownText.text = (Math.Truncate(spiritCast.GetSLG_timer() * 100) / 100).ToString();
		}
	}
}