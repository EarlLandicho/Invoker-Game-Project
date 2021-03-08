#region

using UnityEngine;

#endregion

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class MovementFlip : MonoBehaviour
{
	[SerializeField] private bool initialSpriteIsTurnedLeft;
	private bool facingRight = true;
	private Rigidbody2D rigidbody2d;
	private SpriteRenderer spriteRenderer;

	private void Awake()
	{
		rigidbody2d = GetComponent<Rigidbody2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		if (initialSpriteIsTurnedLeft)
		{
			spriteRenderer.flipX = true;
		}
	}

	private void Update()
	{
		FlipCheck();
	}

	public bool GetIsFacingRight()
	{
		return facingRight;
	}

	public void FaceRight()
	{
		transform.rotation = Quaternion.Euler(0, 0, 0);
		facingRight = true;
	}

	public void FaceLeft()
	{
		transform.rotation = Quaternion.Euler(0, 180, 0);
		facingRight = false;
	}

	private void FlipCheck()
	{
		if (rigidbody2d.velocity.x < -0.1f)
		{
			transform.rotation = Quaternion.Euler(0, 180, 0);
			facingRight = false;
		}
		else if (rigidbody2d.velocity.x > 0.1f)
		{
			transform.rotation = Quaternion.Euler(0, 0, 0);
			facingRight = true;
		}
	}
}