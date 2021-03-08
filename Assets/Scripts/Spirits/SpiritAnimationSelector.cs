#region

using UnityEngine;

#endregion

[RequireComponent(typeof(SpiritInput))]
public class SpiritAnimationSelector : MonoBehaviour
{
	//SpriteRenderers of the child sprite objects
	[SerializeField] private SpriteRenderer spiritPosition1SpriteRenderer;
	[SerializeField] private SpriteRenderer spiritPosition2SpriteRenderer;
	[SerializeField] private SpriteRenderer spiritPosition3SpriteRenderer;
	[SerializeField] private ParticleSystem spiritPosition1SpriteRendererParticleSystem;
	[SerializeField] private ParticleSystem spiritPosition2SpriteRendererParticleSystem;
	[SerializeField] private ParticleSystem spiritPosition3SpriteRendererParticleSystem;
	[SerializeField] private Sprite spirit1Sprite;
	[SerializeField] private Sprite spirit2Sprite;
	[SerializeField] private Sprite spirit3Sprite;
	[SerializeField] private GameObject spirit1Animation;
	[SerializeField] private GameObject spirit2Animation;
	[SerializeField] private GameObject spirit3Animation;
	private Color blue;
	private Color brown;
	private ParticleSystem.MainModule main1;
	private ParticleSystem.MainModule main2;
	private ParticleSystem.MainModule main3;
	private SpiritArrayManager spiritArrayManager;
	private int[] spiritArrayManagerArray;
	private SpiritCast spiritCast;
	private Color violet;

	private void Awake()
	{
		spiritArrayManager = GameObject.Find("GameManager").GetComponent<SpiritArrayManager>();
		spiritCast = GameObject.Find("Spirits").GetComponent<SpiritCast>();
		GetComponent<SpiritInput>().UpdateSpiritAnimation += UpdateRotatingSpirits;
		//GetComponent<SpiritInput>().InvokeSpiritsButtonPressed += AnimateSpiritExplosion;
		spiritCast.CastSuccessful += AnimateSpiritExplosion;
	}

	private void Start()
	{
		spiritArrayManagerArray = spiritArrayManager.GetSpiritArray();
		spiritPosition1SpriteRenderer.enabled = false;
		spiritPosition2SpriteRenderer.enabled = false;
		spiritPosition3SpriteRenderer.enabled = false;
		main1 = spiritPosition1SpriteRendererParticleSystem.main;
		main2 = spiritPosition2SpriteRendererParticleSystem.main;
		main3 = spiritPosition3SpriteRendererParticleSystem.main;
		brown = new Color(0.760f, 0.556f, 0.019f);
		blue = new Color(0.019f, 0.223f, 0.760f);
		violet = new Color(0.423f, 0.019f, 0.760f);
		spiritPosition1SpriteRendererParticleSystem.gameObject.SetActive(false);
		spiritPosition2SpriteRendererParticleSystem.gameObject.SetActive(false);
		spiritPosition3SpriteRendererParticleSystem.gameObject.SetActive(false);
	}

	private void AnimateSpiritExplosion()
	{
		for (int i = 0; i < 3; i++)
		{
			if (i == 0)
			{
				switch (spiritArrayManagerArray[i])
				{
					case 0:
						break;
					case 1:
						Instantiate(spirit1Animation, spiritPosition1SpriteRenderer.gameObject.transform.position,
									spiritPosition1SpriteRenderer.transform.rotation);
						break;
					case 2:
						Instantiate(spirit2Animation, spiritPosition1SpriteRenderer.gameObject.transform.position,
									spiritPosition2SpriteRenderer.transform.rotation);
						break;
					case 3:
						Instantiate(spirit3Animation, spiritPosition1SpriteRenderer.gameObject.transform.position,
									spiritPosition3SpriteRenderer.transform.rotation);
						break;
				}
			}
			else if (i == 1)
			{
				switch (spiritArrayManagerArray[i])
				{
					case 0:
						break;
					case 1:
						Instantiate(spirit1Animation, spiritPosition2SpriteRenderer.gameObject.transform.position,
									spiritPosition1SpriteRenderer.transform.rotation);
						break;
					case 2:
						Instantiate(spirit2Animation, spiritPosition2SpriteRenderer.gameObject.transform.position,
									spiritPosition2SpriteRenderer.transform.rotation);
						break;
					case 3:
						Instantiate(spirit3Animation, spiritPosition2SpriteRenderer.gameObject.transform.position,
									spiritPosition3SpriteRenderer.transform.rotation);
						break;
				}
			}
			else if (i == 2)
			{
				switch (spiritArrayManagerArray[i])
				{
					case 0:
						break;
					case 1:
						Instantiate(spirit1Animation, spiritPosition3SpriteRenderer.gameObject.transform.position,
									spiritPosition1SpriteRenderer.transform.rotation);
						break;
					case 2:
						Instantiate(spirit2Animation, spiritPosition3SpriteRenderer.gameObject.transform.position,
									spiritPosition2SpriteRenderer.transform.rotation);
						break;
					case 3:
						Instantiate(spirit3Animation, spiritPosition3SpriteRenderer.gameObject.transform.position,
									spiritPosition3SpriteRenderer.transform.rotation);
						break;
				}
			}
		}
	}

	//called by event
	private void UpdateRotatingSpirits()
	{
		UpdateSpritePosition1();
		UpdateSpritePosition2();
		UpdateSpritePosition3();
	}

	private void UpdateSpritePosition1()
	{
		switch (spiritArrayManagerArray[0])
		{
			case 0:
				spiritPosition1SpriteRenderer.enabled = false;
				spiritPosition1SpriteRendererParticleSystem.gameObject.SetActive(false);
				break;
			case 1:
				spiritPosition1SpriteRenderer.sprite = spirit1Sprite;
				spiritPosition1SpriteRenderer.enabled = true;
				spiritPosition1SpriteRendererParticleSystem.gameObject.SetActive(true);
				main1.startColor = brown;
				break;
			case 2:
				spiritPosition1SpriteRenderer.sprite = spirit2Sprite;
				spiritPosition1SpriteRenderer.enabled = true;
				spiritPosition1SpriteRendererParticleSystem.gameObject.SetActive(true);
				main1.startColor = blue;
				break;
			case 3:
				spiritPosition1SpriteRenderer.sprite = spirit3Sprite;
				spiritPosition1SpriteRenderer.enabled = true;
				spiritPosition1SpriteRendererParticleSystem.gameObject.SetActive(true);
				main1.startColor = violet;
				break;
		}
	}

	private void UpdateSpritePosition2()
	{
		switch (spiritArrayManagerArray[1])
		{
			case 0:
				spiritPosition2SpriteRenderer.enabled = false;
				spiritPosition2SpriteRendererParticleSystem.gameObject.SetActive(false);
				break;
			case 1:
				spiritPosition2SpriteRenderer.sprite = spirit1Sprite;
				spiritPosition2SpriteRenderer.enabled = true;
				spiritPosition2SpriteRendererParticleSystem.gameObject.SetActive(true);
				main2.startColor = brown;
				break;
			case 2:
				spiritPosition2SpriteRenderer.sprite = spirit2Sprite;
				spiritPosition2SpriteRenderer.enabled = true;
				spiritPosition2SpriteRendererParticleSystem.gameObject.SetActive(true);
				main2.startColor = blue;
				break;
			case 3:
				spiritPosition2SpriteRenderer.sprite = spirit3Sprite;
				spiritPosition2SpriteRenderer.enabled = true;
				spiritPosition2SpriteRendererParticleSystem.gameObject.SetActive(true);
				main2.startColor = violet;
				break;
		}
	}

	private void UpdateSpritePosition3()
	{
		switch (spiritArrayManagerArray[2])
		{
			case 0:
				spiritPosition3SpriteRenderer.enabled = false;
				spiritPosition3SpriteRendererParticleSystem.gameObject.SetActive(false);
				break;
			case 1:
				spiritPosition3SpriteRenderer.sprite = spirit1Sprite;
				spiritPosition3SpriteRenderer.enabled = true;
				spiritPosition3SpriteRendererParticleSystem.gameObject.SetActive(true);
				main3.startColor = brown;
				break;
			case 2:
				spiritPosition3SpriteRenderer.sprite = spirit2Sprite;
				spiritPosition3SpriteRenderer.enabled = true;
				spiritPosition3SpriteRendererParticleSystem.gameObject.SetActive(true);
				main3.startColor = blue;
				break;
			case 3:
				spiritPosition3SpriteRenderer.sprite = spirit3Sprite;
				spiritPosition3SpriteRenderer.enabled = true;
				spiritPosition3SpriteRendererParticleSystem.gameObject.SetActive(true);
				main3.startColor = violet;
				break;
		}
	}
}