#region

using UnityEngine;
using Random = Unity.Mathematics.Random;

#endregion

public class EnemyHealth : Health
{
	[SerializeField] private GameObject deathAnimationObject;
	[SerializeField] private float comboBarIncreaseAmount = 5;
	[SerializeField] private AudioClip[] deathAudioClips;

	
	private AudioSource audioSource;
	private ComboBar comboBar;

	private new void Awake()
	{
		base.Awake();
		comboBar = FindObjectOfType<ComboBar>();
		audioSource = GameObject.Find("EnemyDeathAudio").GetComponent<AudioSource>();
	}

	protected override void Die()
	{
		comboBar.IncreaseComboBarLevel(comboBarIncreaseAmount);
		Instantiate(deathAnimationObject, transform.position, transform.rotation);
		audioSource.PlayOneShot(deathAudioClips[UnityEngine.Random.Range(0, deathAudioClips.Length - 1)]);
		Destroy(gameObject);
	}

	private void SelfDie()
	{
		Instantiate(deathAnimationObject, transform.position, transform.rotation);
		Destroy(gameObject);
	}
}