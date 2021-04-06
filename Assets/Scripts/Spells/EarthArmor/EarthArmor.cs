#region

using System.Collections;
using UnityEngine;

#endregion

public class EarthArmor : MonoBehaviour
{
	[Range(0, 1)] [SerializeField] private float percentDamageDecrease;
	[Range(0, 1)] [SerializeField] private float comboBarAddedPercentDamageDecrease;
	[SerializeField] private float duration;
	[SerializeField] private GameObject armorShield;
	private StatusEffect playerStatusEffect;
	
	private ComboBar comboBar;


	private void Awake()
	{
		playerStatusEffect = GameObject.Find("Player").GetComponent<StatusEffect>();
		comboBar = GameObject.Find("GameManager").GetComponent<ComboBar>();

	}

	private void Start()
	{
		ComboBarCheck();
		playerStatusEffect.BecomeArmored(percentDamageDecrease, duration);
		//Instantiate(armorShield, transform.position, transform.rotation);
		StartCoroutine("ArmorDuration");
	}

	private IEnumerator ArmorDuration()
	{
		yield return new WaitForSeconds(duration);
		Destroy(gameObject);
	}
	
	private void ComboBarCheck()
	{
		switch (comboBar.GetComboBarStage())
		{
			case 2:
				percentDamageDecrease += comboBarAddedPercentDamageDecrease;
				break;
			case 3:
			case 4:
				percentDamageDecrease += 2 * comboBarAddedPercentDamageDecrease;
				break;
			default:
				return;
		}
	}
}