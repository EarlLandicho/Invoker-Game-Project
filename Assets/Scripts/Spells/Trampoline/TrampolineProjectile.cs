#region

using UnityEngine;

#endregion

public class TrampolineProjectile : MonoBehaviour
{
	[SerializeField] private float projectileDistance;
	[SerializeField] private float projectileTime;
	private bool isRight;

	private void Start()
	{
		if (isRight)
		{
			LeanTween.moveX(gameObject, gameObject.transform.position.x + projectileDistance, projectileTime)
					 .setEaseOutQuad();
		}
		else
		{
			LeanTween.moveX(gameObject, gameObject.transform.position.x - projectileDistance, projectileTime)
					 .setEaseOutQuad();
		}

		LeanTween.value(gameObject, 1f, 0, projectileTime).setEaseInOutSine().setOnUpdate(value =>
		{
			var spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
			var newColor = spriteRenderer.color;
			newColor.a = value;
			spriteRenderer.color = newColor;
		}).setOnComplete(DestroyProjectile);
	}

	public void SetIsRight(bool isRight)
	{
		this.isRight = isRight;
	}

	private void DestroyProjectile()
	{
		Destroy(gameObject);
	}
}