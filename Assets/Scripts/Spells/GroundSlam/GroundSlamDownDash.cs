#region

using UnityEngine;

#endregion

public class GroundSlamDownDash : MonoBehaviour
{
	[SerializeField] private float forceY;
	private PlayerJump playerJump;
	private Rigidbody2D playerRigidBody;
	private bool wasGrounded;

	private void Awake()
	{
		playerRigidBody = GameObject.Find("Player").GetComponent<Rigidbody2D>();
		playerJump = GameObject.Find("Player").GetComponent<PlayerJump>();
		playerRigidBody.AddForce(new Vector2(0, forceY));
	}
}