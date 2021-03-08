#region

using System;
using UnityEngine;

#endregion

//S = earth spirit
//L = water spirit
//G = air spirit

[RequireComponent(typeof(SpiritInput))]
public class SpiritCast : MonoBehaviour
{
	[SerializeField] private float spellCastComboBarIncreaseAmount;

	
	[SerializeField] private GameObject S_spell,
										L_spell,
										G_spell,
										SS_spell,
										LL_spell,
										GG_spell,
										SL_spell,
										SG_spell,
										LG_spell,
										SSS_spell,
										LLL_spell,
										GGG_spell,
										SSL_spell,
										SSG_spell,
										SLL_spell,
										SGG_spell,
										LLG_spell,
										LGG_spell,
										SLG_spell;


	[SerializeField] private float S_cooldown,
								   L_cooldown,
								   G_cooldown,
								   SS_cooldown,
								   LL_cooldown,
								   GG_cooldown,
								   SL_cooldown,
								   SG_cooldown,
								   LG_cooldown,
								   SSS_cooldown,
								   LLL_cooldown,
								   GGG_cooldown,
								   SSL_cooldown,
								   SSG_cooldown,
								   SLL_cooldown,
								   SGG_cooldown,
								   LLG_cooldown,
								   LGG_cooldown,
								   SLG_cooldown;

	private int castNumber;
	private ComboBar comboBar;
	private GameObject player;

	private bool S_isOffCooldown = true,
				 L_isOffCooldown = true,
				 G_isOffCooldown = true,
				 SS_isOffCooldown = true,
				 LL_isOffCooldown = true,
				 GG_isOffCooldown = true,
				 SL_isOffCooldown = true,
				 SG_isOffCooldown = true,
				 LG_isOffCooldown = true,
				 SSS_isOffCooldown = true,
				 LLL_isOffCooldown = true,
				 GGG_isOffCooldown = true,
				 SSL_isOffCooldown = true,
				 SSG_isOffCooldown = true,
				 SLL_isOffCooldown = true,
				 SGG_isOffCooldown = true,
				 LLG_isOffCooldown = true,
				 LGG_isOffCooldown = true,
				 SLG_isOffCooldown = true;

	private float S_timer,
				  L_timer,
				  G_timer,
				  SS_timer,
				  LL_timer,
				  GG_timer,
				  SL_timer,
				  SG_timer,
				  LG_timer,
				  SSS_timer,
				  LLL_timer,
				  GGG_timer,
				  SSL_timer,
				  SSG_timer,
				  SLL_timer,
				  SGG_timer,
				  LLG_timer,
				  LGG_timer,
				  SLG_timer;

	private SpiritArrayManager spiritArrayManager;
	private int[] spiritArrayManagerArray;

	private void Awake()
	{
		GetComponent<SpiritInput>().InvokeSpiritsButtonPressed += InvokeSpirits;
		CastSuccessful += AddToComboBar;
		spiritArrayManager = GameObject.Find("GameManager").GetComponent<SpiritArrayManager>();
		spiritArrayManagerArray = spiritArrayManager.GetSpiritArray();
		player = GameObject.Find("Player");
		comboBar = FindObjectOfType<ComboBar>();
	}

	private void Start()
	{
		// S_timer = S_cooldown;
		// L_timer = L_cooldown;
		// G_timer = G_cooldown;
		// SS_timer = SS_cooldown;
		// LL_timer = LL_cooldown;
		// GG_timer = G_cooldown;
		// SL_timer = SL_cooldown;
		// SG_timer = SG_cooldown;
		// LG_timer = LG_cooldown;
		// SSS_timer = SSS_cooldown;
		// LLL_timer = LLL_cooldown;
		// GGG_timer = GGG_cooldown;
		// SSL_timer = SSL_cooldown;
		// SSG_timer = SSG_cooldown;
		// SLL_timer = SLL_cooldown;
		// SGG_timer = SGG_cooldown;
		// LLG_timer = LLG_cooldown;
		// LGG_timer = LGG_cooldown;
		// SLG_timer = SLG_cooldown;
	}

	private void Update()
	{
		CheckSpellCooldowns();
	}

	public event Action CastSuccessful = delegate { };

	public bool GetS_isOffCooldown()
	{
		return S_isOffCooldown;
	}

	public bool GetL_isOffCooldown()
	{
		return L_isOffCooldown;
	}

	public bool GetG_isOffCooldown()
	{
		return G_isOffCooldown;
	}

	public bool GetSS_isOffCooldown()
	{
		return SS_isOffCooldown;
	}

	public bool GetLL_isOffCooldown()
	{
		return LL_isOffCooldown;
	}

	public bool GetGG_isOffCooldown()
	{
		return GG_isOffCooldown;
	}

	public bool GetSL_isOffCooldown()
	{
		return SL_isOffCooldown;
	}

	public bool GetSG_isOffCooldown()
	{
		return SG_isOffCooldown;
	}

	public bool GetLG_isOffCooldown()
	{
		return LG_isOffCooldown;
	}

	public bool GetSSS_isOffCooldown()
	{
		return SSS_isOffCooldown;
	}

	public bool GetLLL_isOffCooldown()
	{
		return LLL_isOffCooldown;
	}

	public bool GetGGG_isOffCooldown()
	{
		return GGG_isOffCooldown;
	}

	public bool GetSSL_isOffCooldown()
	{
		return SSL_isOffCooldown;
	}

	public bool GetSSG_isOffCooldown()
	{
		return SSG_isOffCooldown;
	}

	public bool GetSLL_isOffCooldown()
	{
		return SLL_isOffCooldown;
	}

	public bool GetSGG_isOffCooldown()
	{
		return SGG_isOffCooldown;
	}

	public bool GetLLG_isOffCooldown()
	{
		return LLG_isOffCooldown;
	}

	public bool GetLGG_isOffCooldown()
	{
		return LGG_isOffCooldown;
	}

	public bool GetSLG_isOffCooldown()
	{
		return SLG_isOffCooldown;
	}

	public float GetS_cooldown()
	{
		return S_cooldown;
	}

	public float GetL_cooldown()
	{
		return L_cooldown;
	}

	public float GetG_cooldown()
	{
		return G_cooldown;
	}

	public float GetSS_cooldown()
	{
		return SS_cooldown;
	}

	public float GetLL_cooldown()
	{
		return LL_cooldown;
	}

	public float GetGG_cooldown()
	{
		return GG_cooldown;
	}

	public float GetSL_cooldown()
	{
		return SL_cooldown;
	}

	public float GetSG_cooldown()
	{
		return SG_cooldown;
	}

	public float GetLG_cooldown()
	{
		return LG_cooldown;
	}

	public float GetSSS_cooldown()
	{
		return SSS_cooldown;
	}

	public float GetLLL_cooldown()
	{
		return LLL_cooldown;
	}

	public float GetGGG_cooldown()
	{
		return GGG_cooldown;
	}

	public float GetSSL_cooldown()
	{
		return SSL_cooldown;
	}

	public float GetSSG_cooldown()
	{
		return SSG_cooldown;
	}

	public float GetSLL_cooldown()
	{
		return SLL_cooldown;
	}

	public float GetSGG_cooldown()
	{
		return SGG_cooldown;
	}

	public float GetLLG_cooldown()
	{
		return LLG_cooldown;
	}

	public float GetLGG_cooldown()
	{
		return LGG_cooldown;
	}

	public float GetSLG_cooldown()
	{
		return SLG_cooldown;
	}
	
	public float GetS_timer()
	{
		return S_timer;
	}

	public float GetL_timer()
	{
		return L_timer;
	}

	public float GetG_timer()
	{
		return G_timer;
	}

	public float GetSS_timer()
	{
		return SS_timer;
	}

	public float GetLL_timer()
	{
		return LL_timer;
	}

	public float GetGG_timer()
	{
		return GG_timer;
	}

	public float GetSL_timer()
	{
		return SL_timer;
	}

	public float GetSG_timer()
	{
		return SG_timer;
	}

	public float GetLG_timer()
	{
		return LG_timer;
	}

	public float GetSSS_timer()
	{
		return SSS_timer;
	}

	public float GetLLL_timer()
	{
		return LLL_timer;
	}

	public float GetGGG_timer()
	{
		return GGG_timer;
	}

	public float GetSSL_timer()
	{
		return SSL_timer;
	}

	public float GetSSG_timer()
	{
		return SSG_timer;
	}

	public float GetSLL_timer()
	{
		return SLL_timer;
	}

	public float GetSGG_timer()
	{
		return SGG_timer;
	}

	public float GetLLG_timer()
	{
		return LLG_timer;
	}

	public float GetLGG_timer()
	{
		return LGG_timer;
	}

	public float GetSLG_timer()
	{
		return SLG_timer;
	}

	public void ResetAllCooldowns()
	{
		S_timer = S_cooldown;
		L_timer = L_cooldown;
		G_timer = G_cooldown;
		SS_timer = SS_cooldown;
		LL_timer = LL_cooldown;
		GG_timer = G_cooldown;
		SL_timer = SL_cooldown;
		SG_timer = SG_cooldown;
		LG_timer = LG_cooldown;
		SSS_timer = SSS_cooldown;
		LLL_timer = LLL_cooldown;
		GGG_timer = GGG_cooldown;
		SSL_timer = SSL_cooldown;
		SSG_timer = SSG_cooldown;
		SLL_timer = SLL_cooldown;
		SGG_timer = SGG_cooldown;
		LLG_timer = LLG_cooldown;
		LGG_timer = LGG_cooldown;
		SLG_timer = SLG_cooldown;
		S_isOffCooldown = true;
		L_isOffCooldown = true;
		G_isOffCooldown = true;
		SS_isOffCooldown = true;
		LL_isOffCooldown = true;
		GG_isOffCooldown = true;
		SL_isOffCooldown = true;
		SG_isOffCooldown = true;
		LG_isOffCooldown = true;
		SSS_isOffCooldown = true;
		LLL_isOffCooldown = true;
		GGG_isOffCooldown = true;
		SSL_isOffCooldown = true;
		SSG_isOffCooldown = true;
		SLL_isOffCooldown = true;
		SGG_isOffCooldown = true;
		LLG_isOffCooldown = true;
		LGG_isOffCooldown = true;
		SLG_isOffCooldown = true;
	}

	private void CheckSpellCooldowns()
	{
		if (!S_isOffCooldown)
		{
			if (S_timer > 0)
			{
				S_timer -= Time.deltaTime;
			}
			else
			{
				S_isOffCooldown = true;
			}
		}

		if (!L_isOffCooldown)
		{
			if (L_timer > 0)
			{
				L_timer -= Time.deltaTime;
			}
			else
			{
				L_isOffCooldown = true;
			}
		}

		if (!G_isOffCooldown)
		{
			if (G_timer > 0)
			{
				G_timer -= Time.deltaTime;
			}
			else
			{
				G_isOffCooldown = true;
			}
		}

		if (!SS_isOffCooldown)
		{
			if (SS_timer > 0)
			{
				SS_timer -= Time.deltaTime;
			}
			else
			{
				SS_isOffCooldown = true;
			}
		}

		if (!LL_isOffCooldown)
		{
			if (LL_timer > 0)
			{
				LL_timer -= Time.deltaTime;
			}
			else
			{
				LL_isOffCooldown = true;
			}
		}

		if (!GG_isOffCooldown)
		{
			if (GG_timer > 0)
			{
				GG_timer -= Time.deltaTime;
			}
			else
			{
				GG_isOffCooldown = true;
			}
		}

		if (!SL_isOffCooldown)
		{
			if (SL_timer > 0)
			{
				SL_timer -= Time.deltaTime;
			}
			else
			{
				SL_isOffCooldown = true;
			}
		}

		if (!SG_isOffCooldown)
		{
			if (SG_timer > 0)
			{
				SG_timer -= Time.deltaTime;
			}
			else
			{
				SG_isOffCooldown = true;
			}
		}

		if (!LG_isOffCooldown)
		{
			if (LG_timer > 0)
			{
				LG_timer -= Time.deltaTime;
			}
			else
			{
				LG_isOffCooldown = true;
			}
		}

		if (!SSS_isOffCooldown)
		{
			if (SSS_timer > 0)
			{
				SSS_timer -= Time.deltaTime;
			}
			else
			{
				SSS_isOffCooldown = true;
			}
		}

		if (!LLL_isOffCooldown)
		{
			if (LLL_timer > 0)
			{
				LLL_timer -= Time.deltaTime;
			}
			else
			{
				LLL_isOffCooldown = true;
			}
		}

		if (!GGG_isOffCooldown)
		{
			if (GGG_timer > 0)
			{
				GGG_timer -= Time.deltaTime;
			}
			else
			{
				GGG_isOffCooldown = true;
			}
		}

		if (!SSL_isOffCooldown)
		{
			if (SSL_timer > 0)
			{
				SSL_timer -= Time.deltaTime;
			}
			else
			{
				SSL_isOffCooldown = true;
			}
		}

		if (!SSG_isOffCooldown)
		{
			if (SSG_timer > 0)
			{
				SSG_timer -= Time.deltaTime;
			}
			else
			{
				SSG_isOffCooldown = true;
			}
		}

		if (!SLL_isOffCooldown)
		{
			if (SLL_timer > 0)
			{
				SLL_timer -= Time.deltaTime;
			}
			else
			{
				SLL_isOffCooldown = true;
			}
		}

		if (!SGG_isOffCooldown)
		{
			if (SGG_timer > 0)
			{
				SGG_timer -= Time.deltaTime;
			}
			else
			{
				SGG_isOffCooldown = true;
			}
		}

		if (!LLG_isOffCooldown)
		{
			if (LLG_timer > 0)
			{
				LLG_timer -= Time.deltaTime;
			}
			else
			{
				LLG_isOffCooldown = true;
			}
		}

		if (!LGG_isOffCooldown)
		{
			if (LGG_timer > 0)
			{
				LGG_timer -= Time.deltaTime;
			}
			else
			{
				LGG_isOffCooldown = true;
			}
		}

		if (!SLG_isOffCooldown)
		{
			if (SLG_timer > 0)
			{
				SLG_timer -= Time.deltaTime;
			}
			else
			{
				SLG_isOffCooldown = true;
			}
		}
	}

	private void InvokeSpirits()
	{
		for (var i = 0; i < spiritArrayManagerArray.Length; i++)
		{
			if (spiritArrayManagerArray[i] == 1)
			{
				castNumber += 100;
			}
			else if (spiritArrayManagerArray[i] == 2)
			{
				castNumber += 10;
			}
			else if (spiritArrayManagerArray[i] == 3)
			{
				castNumber += 1;
			}
		}

		//PrintCastNumber();
		Cast(castNumber);
		castNumber = 0;
	}

	private void Cast(int castNum)
	{
		switch (castNum)
		{
			case 100:
				S();
				break;
			case 10:
				L();
				break;
			case 1:
				G();
				break;
			case 200:
				SS();
				break;
			case 20:
				LL();
				break;
			case 2:
				GG();
				break;
			case 110:
				SL();
				break;
			case 101:
				SG();
				break;
			case 11:
				LG();
				break;
			case 300:
				SSS();
				break;
			case 30:
				LLL();
				break;
			case 3:
				GGG();
				break;
			case 210:
				SSL();
				break;
			case 201:
				SSG();
				break;
			case 120:
				SLL();
				break;
			case 102:
				SGG();
				break;
			case 21:
				LLG();
				break;
			case 12:
				LGG();
				break;
			case 111:
				SLG();
				break;
		}
	}

	private void AddToComboBar()
	{
		comboBar.IncreaseComboBarLevel(spellCastComboBarIncreaseAmount);
	}

	private void S()
	{
		if (S_isOffCooldown)
		{
			Instantiate(S_spell, ExtensionMethods.GetPlayerPosition(), player.transform.rotation);
			S_timer = S_cooldown;
			S_isOffCooldown = false;
			CastSuccessful();
			spiritArrayManager.ClearSpirits();
		}
	}

	private void L()
	{
		if (L_isOffCooldown)
		{
			Instantiate(L_spell, ExtensionMethods.GetPlayerPosition(), player.transform.rotation);
			L_timer = L_cooldown;
			L_isOffCooldown = false;
			CastSuccessful();
			spiritArrayManager.ClearSpirits();
		}
		else
		{
			Debug.Log("Still cooling down");
		}
	}

	private void G()
	{
		if (G_isOffCooldown)
		{
			Instantiate(G_spell, ExtensionMethods.GetPlayerPosition(), player.transform.rotation);
			G_timer = G_cooldown;
			G_isOffCooldown = false;
			CastSuccessful();
			spiritArrayManager.ClearSpirits();
		}
		else
		{
			Debug.Log("Still cooling down");
		}
	}

	private void SS()
	{
		if (SS_isOffCooldown)
		{
			Instantiate(SS_spell, ExtensionMethods.GetPlayerPosition(), player.transform.rotation);
			SS_timer = SS_cooldown;
			SS_isOffCooldown = false;
			CastSuccessful();
			spiritArrayManager.ClearSpirits();
		}
		else
		{
			Debug.Log("Still cooling down");
		}
	}

	private void LL()
	{
		if (LL_isOffCooldown)
		{
			Instantiate(LL_spell, ExtensionMethods.GetPlayerPosition(), player.transform.rotation);
			LL_timer = LL_cooldown;
			LL_isOffCooldown = false;
			CastSuccessful();
			spiritArrayManager.ClearSpirits();
		}
		else
		{
			Debug.Log("Still cooling down");
		}
	}

	private void GG()
	{
		if (GG_isOffCooldown)
		{
			Instantiate(GG_spell, ExtensionMethods.GetPlayerPosition(), player.transform.rotation);
			GG_timer = GG_cooldown;
			GG_isOffCooldown = false;
			CastSuccessful();
			spiritArrayManager.ClearSpirits();
		}
		else
		{
			Debug.Log("Still cooling down");
		}
	}

	private void SL()
	{
		if (SL_isOffCooldown)
		{
			Instantiate(SL_spell, ExtensionMethods.GetPlayerPosition(), player.transform.rotation);
			SL_timer = SL_cooldown;
			SL_isOffCooldown = false;
			CastSuccessful();
			spiritArrayManager.ClearSpirits();
		}
		else
		{
			Debug.Log("Still cooling down");
		}
	}

	private void SG()
	{
		if (SG_isOffCooldown)
		{
			Instantiate(SG_spell, ExtensionMethods.GetPlayerPosition(), player.transform.rotation);
			SG_timer = SG_cooldown;
			SG_isOffCooldown = false;
			CastSuccessful();
			spiritArrayManager.ClearSpirits();
		}
		else
		{
			Debug.Log("Still cooling down");
		}
	}

	private void LG()
	{
		if (LG_isOffCooldown)
		{
			Instantiate(LG_spell, ExtensionMethods.GetPlayerPosition(), player.transform.rotation);
			LG_timer = LG_cooldown;
			LG_isOffCooldown = false;
			CastSuccessful();
			spiritArrayManager.ClearSpirits();
		}
		else
		{
			Debug.Log("Still cooling down");
		}
	}

	private void SSS()
	{
		if (SSS_isOffCooldown)
		{
			Instantiate(SSS_spell, ExtensionMethods.GetPlayerPosition(), player.transform.rotation);
			SSS_timer = SSS_cooldown;
			SSS_isOffCooldown = false;
			CastSuccessful();
			spiritArrayManager.ClearSpirits();
		}
		else
		{
			Debug.Log("Still cooling down");
		}
	}

	private void LLL()
	{
		if (LLL_isOffCooldown)
		{
			Instantiate(LLL_spell, ExtensionMethods.GetPlayerPosition(), player.transform.rotation);
			LLL_timer = LLL_cooldown;
			LLL_isOffCooldown = false;
			CastSuccessful();
			spiritArrayManager.ClearSpirits();
		}
		else
		{
			Debug.Log("Still cooling down");
		}
	}

	private void GGG()
	{
		if (GGG_isOffCooldown)
		{
			Instantiate(GGG_spell, ExtensionMethods.GetPlayerPosition(), player.transform.rotation);
			GGG_timer = GGG_cooldown;
			GGG_isOffCooldown = false;
			CastSuccessful();
			spiritArrayManager.ClearSpirits();
		}
		else
		{
			Debug.Log("Still cooling down");
		}
	}

	private void SSL()
	{
		if (SSL_isOffCooldown)
		{
			Instantiate(SSL_spell, ExtensionMethods.GetPlayerPosition(), player.transform.rotation);
			SSL_timer = SSL_cooldown;
			SSL_isOffCooldown = false;
			CastSuccessful();
			spiritArrayManager.ClearSpirits();
		}
		else
		{
			Debug.Log("Still cooling down");
		}
	}

	private void SSG()
	{
		if (SSG_isOffCooldown)
		{
			Instantiate(SSG_spell, ExtensionMethods.GetPlayerPosition(), player.transform.rotation);
			SSG_timer = SSG_cooldown;
			SSG_isOffCooldown = false;
			CastSuccessful();
			spiritArrayManager.ClearSpirits();
		}
		else
		{
			Debug.Log("Still cooling down");
		}
	}

	private void SLL()
	{
		if (SLL_isOffCooldown)
		{
			Instantiate(SLL_spell, ExtensionMethods.GetPlayerPosition(), player.transform.rotation);
			SLL_timer = SLL_cooldown;
			SLL_isOffCooldown = false;
			CastSuccessful();
			spiritArrayManager.ClearSpirits();
		}
		else
		{
			Debug.Log("Still cooling down");
		}
	}

	private void SGG()
	{
		if (SGG_isOffCooldown)
		{
			Instantiate(SGG_spell, ExtensionMethods.GetPlayerPosition(), player.transform.rotation);
			SGG_timer = SGG_cooldown;
			SGG_isOffCooldown = false;
			CastSuccessful();
			spiritArrayManager.ClearSpirits();
		}
		else
		{
			Debug.Log("Still cooling down");
		}
	}

	private void LLG()
	{
		if (LLG_isOffCooldown)
		{
			Instantiate(LLG_spell, ExtensionMethods.GetPlayerPosition(), player.transform.rotation);
			LLG_timer = LLG_cooldown;
			LLG_isOffCooldown = false;
			CastSuccessful();
			spiritArrayManager.ClearSpirits();
		}
		else
		{
			Debug.Log("Still cooling down");
		}
	}

	private void LGG()
	{
		if (LGG_isOffCooldown)
		{
			Instantiate(LGG_spell, ExtensionMethods.GetPlayerPosition(), player.transform.rotation);
			LGG_timer = LGG_cooldown;
			LGG_isOffCooldown = false;
			CastSuccessful();
			spiritArrayManager.ClearSpirits();
		}
		else
		{
			Debug.Log("Still cooling down");
		}
	}

	private void SLG()
	{
		if (SLG_isOffCooldown)
		{
			Instantiate(SLG_spell, ExtensionMethods.GetPlayerPosition(), player.transform.rotation);
			SLG_timer = SLG_cooldown;
			SLG_isOffCooldown = false;
			CastSuccessful();
			spiritArrayManager.ClearSpirits();
		}
		else
		{
			Debug.Log("Still cooling down");
		}
	}

	private void PrintCastNumber()
	{
		Debug.LogFormat("Cast Number is {0}", castNumber);
	}

	private void PrintSpiritArray()
	{
		Debug.LogFormat("Current Array: [ {0}, {1}, {2} ]", spiritArrayManagerArray[0], spiritArrayManagerArray[1],
						spiritArrayManagerArray[2]);
	}

	private void CooldownAlert()
	{
	}
}