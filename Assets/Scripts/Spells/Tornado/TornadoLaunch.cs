#region

using UnityEngine;

#endregion

public class TornadoLaunch : MonoBehaviour
{
	[SerializeField] private float distanceX;
	[SerializeField] private float duration;
	private MovementFlip playerMovementFlip;

	private void Awake()
	{
		playerMovementFlip = GameObject.Find("Player").GetComponent<MovementFlip>();
		if (!playerMovementFlip.GetIsFacingRight())
		{
			distanceX *= -1;
		}

		LeanTween.moveX(gameObject, gameObject.transform.position.x + distanceX, duration).setEaseOutQuad()
				 .setOnComplete(OnComplete);
	}

	private void OnComplete()
	{
		Destroy(gameObject);
	}
}