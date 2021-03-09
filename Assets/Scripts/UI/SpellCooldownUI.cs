#region

using UnityEngine;
using UnityEngine.UI;

#endregion

public class SpellCooldownUI : MonoBehaviour
{
	[SerializeField] private float alphaValue;
	[SerializeField] private GameObject S_spell;
	[SerializeField] private GameObject L_spell;
	[SerializeField] private GameObject G_spell;
	[SerializeField] private GameObject SS_spell;
	[SerializeField] private GameObject LL_spell;
	[SerializeField] private GameObject GG_spell;
	[SerializeField] private GameObject SL_spell;
	[SerializeField] private GameObject SG_spell;
	[SerializeField] private GameObject LG_spell;
	[SerializeField] private GameObject SSS_spell;
	[SerializeField] private GameObject LLL_spell;
	[SerializeField] private GameObject GGG_spell;
	[SerializeField] private GameObject SSL_spell;
	[SerializeField] private GameObject SSG_spell;
	[SerializeField] private GameObject SLL_spell;
	[SerializeField] private GameObject SGG_spell;
	[SerializeField] private GameObject LLG_spell;
	[SerializeField] private GameObject LGG_spell;
	[SerializeField] private GameObject SLG_spell;
	

	private Image S_fill,
				  L_fill,
				  G_fill,
				  SS_fill,
				  LL_fill,
				  GG_fill,
				  SL_fill,
				  SG_fill,
				  LG_fill,
				  SSS_fill,
				  LLL_fill,
				  GGG_fill,
				  SSL_fill,
				  SSG_fill,
				  SLL_fill,
				  SGG_fill,
				  LLG_fill,
				  LGG_fill,
				  SLG_fill;

	private Image S_image,
				  L_image,
				  G_image,
				  SS_image,
				  LL_image,
				  GG_image,
				  SL_image,
				  SG_image,
				  LG_image,
				  SSS_image,
				  LLL_image,
				  GGG_image,
				  SSL_image,
				  SSG_image,
				  SLL_image,
				  SGG_image,
				  LLG_image,
				  LGG_image,
				  SLG_image;

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
		G_fill = G_spell.transform.GetChild(0).GetComponent<Image>();
		G_image = G_spell.transform.GetChild(1).GetComponent<Image>();
		SS_fill = SS_spell.transform.GetChild(0).GetComponent<Image>();
		SS_image = SS_spell.transform.GetChild(1).GetComponent<Image>();
		LL_fill = LL_spell.transform.GetChild(0).GetComponent<Image>();
		LL_image = LL_spell.transform.GetChild(1).GetComponent<Image>();
		GG_fill = GG_spell.transform.GetChild(0).GetComponent<Image>();
		GG_image = GG_spell.transform.GetChild(1).GetComponent<Image>();
		SL_fill = SL_spell.transform.GetChild(0).GetComponent<Image>();
		SL_image = SL_spell.transform.GetChild(1).GetComponent<Image>();
		SG_fill = SG_spell.transform.GetChild(0).GetComponent<Image>();
		SG_image = SG_spell.transform.GetChild(1).GetComponent<Image>();
		LG_fill = LG_spell.transform.GetChild(0).GetComponent<Image>();
		LG_image = LG_spell.transform.GetChild(1).GetComponent<Image>();
		SSS_fill = SSS_spell.transform.GetChild(0).GetComponent<Image>();
		SSS_image = SSS_spell.transform.GetChild(1).GetComponent<Image>();
		LLL_fill = LLL_spell.transform.GetChild(0).GetComponent<Image>();
		LLL_image = LLL_spell.transform.GetChild(1).GetComponent<Image>();
		GGG_fill = GGG_spell.transform.GetChild(0).GetComponent<Image>();
		GGG_image = GGG_spell.transform.GetChild(1).GetComponent<Image>();
		SSL_fill = SSL_spell.transform.GetChild(0).GetComponent<Image>();
		SSL_image = SSL_spell.transform.GetChild(1).GetComponent<Image>();
		SSG_fill = SSG_spell.transform.GetChild(0).GetComponent<Image>();
		SSG_image = SSG_spell.transform.GetChild(1).GetComponent<Image>();
		SLL_fill = SLL_spell.transform.GetChild(0).GetComponent<Image>();
		SLL_image = SLL_spell.transform.GetChild(1).GetComponent<Image>();
		SGG_fill = SGG_spell.transform.GetChild(0).GetComponent<Image>();
		SGG_image = SGG_spell.transform.GetChild(1).GetComponent<Image>();
		LLG_fill = LLG_spell.transform.GetChild(0).GetComponent<Image>();
		LLG_image = LLG_spell.transform.GetChild(1).GetComponent<Image>();
		LGG_fill = LGG_spell.transform.GetChild(0).GetComponent<Image>();
		LGG_image = LGG_spell.transform.GetChild(1).GetComponent<Image>();
		SLG_fill = SLG_spell.transform.GetChild(0).GetComponent<Image>();
		SLG_image = SLG_spell.transform.GetChild(1).GetComponent<Image>();
	}

	private void LateUpdate()
	{
		CheckS();
		CheckL();
		CheckG();
		CheckSS();
		CheckLL();
		CheckGG();
		CheckSL();
		CheckSG();
		CheckLG();
		CheckSSS();
		CheckLLL();
		CheckGGG();
		CheckSSL();
		CheckSSG();
		CheckSLL();
		CheckSGG();
		CheckLLG();
		CheckLGG();
		CheckSLG();
	}

	private void CheckS()
	{
		S_fill.fillAmount = (spiritcast.GetS_cooldown() - spiritcast.GetS_timer()) / spiritcast.GetS_cooldown();
		if (spiritcast.GetS_isOffCooldown())
		{
			S_fill.enabled = false;
			Color colorTemp = S_image.color;
			colorTemp.a = alphaValue;
			S_image.color = colorTemp;
		}
		else
		{
			S_fill.enabled = true;
			Color colorTemp = S_image.color;
			colorTemp.a = 1f;
			S_image.color = colorTemp;
		}
	}

	private void CheckL()
	{
		L_fill.fillAmount = (spiritcast.GetL_cooldown() - spiritcast.GetL_timer()) / spiritcast.GetL_cooldown();
		if (spiritcast.GetL_isOffCooldown())
		{
			L_fill.enabled = false;
			Color colorTemp = L_image.color;
			colorTemp.a = alphaValue;
			L_image.color = colorTemp;
		}
		else
		{
			L_fill.enabled = true;
			Color colorTemp = L_image.color;
			colorTemp.a = 1f;
			L_image.color = colorTemp;
		}
	}

	private void CheckG()
	{
		G_fill.fillAmount = (spiritcast.GetG_cooldown() - spiritcast.GetG_timer()) / spiritcast.GetG_cooldown();
		if (spiritcast.GetG_isOffCooldown())
		{
			G_fill.enabled = false;
			Color colorTemp = G_image.color;
			colorTemp.a = alphaValue;
			G_image.color = colorTemp;
		}
		else
		{
			G_fill.enabled = true;
			Color colorTemp = G_image.color;
			colorTemp.a = 1f;
			G_image.color = colorTemp;
		}
	}

	private void CheckSS()
	{
		SS_fill.fillAmount = (spiritcast.GetSS_cooldown() - spiritcast.GetSS_timer()) / spiritcast.GetSS_cooldown();
		if (spiritcast.GetSS_isOffCooldown())
		{
			SS_fill.enabled = false;
			Color colorTemp = SS_image.color;
			colorTemp.a = alphaValue;
			SS_image.color = colorTemp;
		}
		else
		{
			SS_fill.enabled = true;
			Color colorTemp = SS_image.color;
			colorTemp.a = 1f;
			SS_image.color = colorTemp;
		}
	}

	private void CheckLL()
	{
		LL_fill.fillAmount = (spiritcast.GetLL_cooldown() - spiritcast.GetLL_timer()) / spiritcast.GetLL_cooldown();
		if (spiritcast.GetLL_isOffCooldown())
		{
			LL_fill.enabled = false;
			Color colorTemp = LL_image.color;
			colorTemp.a = alphaValue;
			LL_image.color = colorTemp;
		}
		else
		{
			LL_fill.enabled = true;
			Color colorTemp = LL_image.color;
			colorTemp.a = 1f;
			LL_image.color = colorTemp;
		}
	}

	private void CheckGG()
	{
		GG_fill.fillAmount = (spiritcast.GetGG_cooldown() - spiritcast.GetGG_timer()) / spiritcast.GetGG_cooldown();
		if (spiritcast.GetGG_isOffCooldown())
		{
			GG_fill.enabled = false;
			Color colorTemp = GG_image.color;
			colorTemp.a = alphaValue;
			GG_image.color = colorTemp;
		}
		else
		{
			GG_fill.enabled = true;
			Color colorTemp = GG_image.color;
			colorTemp.a = 1f;
			GG_image.color = colorTemp;
		}
	}

	private void CheckSL()
	{
		SL_fill.fillAmount = (spiritcast.GetSL_cooldown() - spiritcast.GetSL_timer()) / spiritcast.GetSL_cooldown();
		if (spiritcast.GetSL_isOffCooldown())
		{
			SL_fill.enabled = false;
			Color colorTemp = SL_image.color;
			colorTemp.a = alphaValue;
			SL_image.color = colorTemp;
		}
		else
		{
			SL_fill.enabled = true;
			Color colorTemp = SL_image.color;
			colorTemp.a = 1f;
			SL_image.color = colorTemp;
		}
	}

	private void CheckSG()
	{
		SG_fill.fillAmount = (spiritcast.GetSG_cooldown() - spiritcast.GetSG_timer()) / spiritcast.GetSG_cooldown();
		if (spiritcast.GetSG_isOffCooldown())
		{
			SG_fill.enabled = false;
			Color colorTemp = SG_image.color;
			colorTemp.a = alphaValue;
			SG_image.color = colorTemp;
		}
		else
		{
			SG_fill.enabled = true;
			Color colorTemp = SG_image.color;
			colorTemp.a = 1f;
			SG_image.color = colorTemp;
		}
	}

	private void CheckLG()
	{
		LG_fill.fillAmount = (spiritcast.GetLG_cooldown() - spiritcast.GetLG_timer()) / spiritcast.GetLG_cooldown();
		if (spiritcast.GetLG_isOffCooldown())
		{
			LG_fill.enabled = false;
			Color colorTemp = LG_image.color;
			colorTemp.a = alphaValue;
			LG_image.color = colorTemp;
		}
		else
		{
			LG_fill.enabled = true;
			Color colorTemp = LG_image.color;
			colorTemp.a = 1f;
			LG_image.color = colorTemp;
		}
	}

	private void CheckSSS()
	{
		SSS_fill.fillAmount = (spiritcast.GetSSS_cooldown() - spiritcast.GetSSS_timer()) / spiritcast.GetSSS_cooldown();
		if (spiritcast.GetSSS_isOffCooldown())
		{
			SSS_fill.enabled = false;
			Color colorTemp = SSS_image.color;
			colorTemp.a = alphaValue;
			SSS_image.color = colorTemp;
		}
		else
		{
			SSS_fill.enabled = true;
			Color colorTemp = SSS_image.color;
			colorTemp.a = 1f;
			SSS_image.color = colorTemp;
		}
	}

	private void CheckLLL()
	{
		LLL_fill.fillAmount = (spiritcast.GetLLL_cooldown() - spiritcast.GetLLL_timer()) / spiritcast.GetLLL_cooldown();
		if (spiritcast.GetLLL_isOffCooldown())
		{
			LLL_fill.enabled = false;
			Color colorTemp = LLL_image.color;
			colorTemp.a = alphaValue;
			LLL_image.color = colorTemp;
		}
		else
		{
			LLL_fill.enabled = true;
			Color colorTemp = LLL_image.color;
			colorTemp.a = 1f;
			LLL_image.color = colorTemp;
		}
	}

	private void CheckGGG()
	{
		GGG_fill.fillAmount = (spiritcast.GetGGG_cooldown() - spiritcast.GetGGG_timer()) / spiritcast.GetGGG_cooldown();
		if (spiritcast.GetGGG_isOffCooldown())
		{
			GGG_fill.enabled = false;
			Color colorTemp = GGG_image.color;
			colorTemp.a = alphaValue;
			GGG_image.color = colorTemp;
		}
		else
		{
			GGG_fill.enabled = true;
			Color colorTemp = GGG_image.color;
			colorTemp.a = 1f;
			GGG_image.color = colorTemp;
		}
	}

	private void CheckSSL()
	{
		SSL_fill.fillAmount = (spiritcast.GetSSL_cooldown() - spiritcast.GetSSL_timer()) / spiritcast.GetSSL_cooldown();
		if (spiritcast.GetSSL_isOffCooldown())
		{
			SSL_fill.enabled = false;
			Color colorTemp = SSL_image.color;
			colorTemp.a = alphaValue;
			SSL_image.color = colorTemp;
		}
		else
		{
			SSL_fill.enabled = true;
			Color colorTemp = SSL_image.color;
			colorTemp.a = 1f;
			SSL_image.color = colorTemp;
		}
	}

	private void CheckSSG()
	{
		SSG_fill.fillAmount = (spiritcast.GetSSG_cooldown() - spiritcast.GetSSG_timer()) / spiritcast.GetSSG_cooldown();
		if (spiritcast.GetSSG_isOffCooldown())
		{
			SSG_fill.enabled = false;
			Color colorTemp = SSG_image.color;
			colorTemp.a = alphaValue;
			SSG_image.color = colorTemp;
		}
		else
		{
			SSG_fill.enabled = true;
			Color colorTemp = SSG_image.color;
			colorTemp.a = 1f;
			SSG_image.color = colorTemp;
		}
	}

	private void CheckSLL()
	{
		SLL_fill.fillAmount = (spiritcast.GetSLL_cooldown() - spiritcast.GetSLL_timer()) / spiritcast.GetSLL_cooldown();
		if (spiritcast.GetSLL_isOffCooldown())
		{
			SLL_fill.enabled = false;
			Color colorTemp = SLL_image.color;
			colorTemp.a = alphaValue;
			SLL_image.color = colorTemp;
		}
		else
		{
			SLL_fill.enabled = true;
			Color colorTemp = SLL_image.color;
			colorTemp.a = 1f;
			SLL_image.color = colorTemp;
		}
	}

	private void CheckSGG()
	{
		SGG_fill.fillAmount = (spiritcast.GetSGG_cooldown() - spiritcast.GetSGG_timer()) / spiritcast.GetSGG_cooldown();
		if (spiritcast.GetSGG_isOffCooldown())
		{
			SGG_fill.enabled = false;
			Color colorTemp = SGG_image.color;
			colorTemp.a = alphaValue;
			SGG_image.color = colorTemp;
		}
		else
		{
			SGG_fill.enabled = true;
			Color colorTemp = SGG_image.color;
			colorTemp.a = 1f;
			SGG_image.color = colorTemp;
		}
	}

	private void CheckLLG()
	{
		LLG_fill.fillAmount = (spiritcast.GetLLG_cooldown() - spiritcast.GetLLG_timer()) / spiritcast.GetLLG_cooldown();
		if (spiritcast.GetLLG_isOffCooldown())
		{
			LLG_fill.enabled = false;
			Color colorTemp = LLG_image.color;
			colorTemp.a = alphaValue;
			LLG_image.color = colorTemp;
		}
		else
		{
			LLG_fill.enabled = true;
			Color colorTemp = LLG_image.color;
			colorTemp.a = 1f;
			LLG_image.color = colorTemp;
		}
	}

	private void CheckLGG()
	{
		LGG_fill.fillAmount = (spiritcast.GetLGG_cooldown() - spiritcast.GetLGG_timer()) / spiritcast.GetLGG_cooldown();
		if (spiritcast.GetLGG_isOffCooldown())
		{
			LGG_fill.enabled = false;
			Color colorTemp = LGG_image.color;
			colorTemp.a = alphaValue;
			LGG_image.color = colorTemp;
		}
		else
		{
			LGG_fill.enabled = true;
			Color colorTemp = LGG_image.color;
			colorTemp.a = 1f;
			LGG_image.color = colorTemp;
		}
	}

	private void CheckSLG()
	{
		SLG_fill.fillAmount = (spiritcast.GetSLG_cooldown() - spiritcast.GetSLG_timer()) / spiritcast.GetSLG_cooldown();
		if (spiritcast.GetSLG_isOffCooldown())
		{
			SLG_fill.enabled = false;
			Color colorTemp = SLG_image.color;
			colorTemp.a = alphaValue;
			SLG_image.color = colorTemp;
		}
		else
		{
			SLG_fill.enabled = true;
			Color colorTemp = SLG_image.color;
			colorTemp.a = 1f;
			SLG_image.color = colorTemp;
		}
	}

	
}