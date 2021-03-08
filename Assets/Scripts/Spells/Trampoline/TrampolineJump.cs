#region

using System;
using System.Collections;
using UnityEngine;

#endregion

public class TrampolineJump : MonoBehaviour
{
	[SerializeField] private float duration;
	[SerializeField] private float upwardForce;
	[SerializeField] private Vector2 size = new Vector2(0, 0);
	private Rigidbody2D playerRigidBody;

	private void Awake()
	{
		playerRigidBody = GameObject.Find("Player").GetComponent<Rigidbody2D>();
		StartCoroutine("SpellLifetime");
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (Physics2D.OverlapBox(transform.position, size, 0, 1 << LayerMask.NameToLayer("Player")))
			{
				playerRigidBody.velocity = new Vector2(0, 0);
				playerRigidBody.AddForce(new Vector2(0, upwardForce));
				TrampolineJumped();
			}
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube((Vector2) transform.position, size);
	}

	public event Action TrampolineJumped = delegate { };

	private IEnumerator SpellLifetime()
	{
		yield return new WaitForSeconds(duration);
		Destroy(gameObject);
	}
}