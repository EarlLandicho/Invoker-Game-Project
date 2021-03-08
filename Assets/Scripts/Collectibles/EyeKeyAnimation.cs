#region

using UnityEngine;

#endregion

public class EyeKeyAnimation : MonoBehaviour
{
	[SerializeField] private float animationTimeDelay;
	private float animationTimeDelayTemp;
	private Animator animator;
	private bool isAnimating;

	private void Awake()
	{
		animator = GetComponent<Animator>();
	}

	private void Start()
	{
		animationTimeDelayTemp = animationTimeDelay;
		LeanTween.moveY(gameObject, gameObject.transform.position.y + .1f, 1f).setEaseInOutSine().setLoopPingPong();
	}

	private void Update()
	{
		if (!isAnimating)
		{
			if (animationTimeDelayTemp > 0)
			{
				animationTimeDelayTemp -= Time.deltaTime;
			}
			else
			{
				animationTimeDelayTemp = animationTimeDelay;
				AnimateRandomIdle();
			}
		}
	}

	// Called in Animator
	public void DisableIsAnimating()
	{
		isAnimating = false;
	}

	private void AnimateRandomIdle()
	{
		var randomNum = Random.Range(0f, 1f);
		if (randomNum >= 0 && randomNum < .33f)
		{
			animator.SetTrigger("idle1");
		}
		else if (randomNum >= .33f && randomNum < .66f)
		{
			animator.SetTrigger("idle2");
		}
		else if (randomNum >= .66f && randomNum < 1f)
		{
			animator.SetTrigger("idle3");
		}

		isAnimating = true;
	}
}