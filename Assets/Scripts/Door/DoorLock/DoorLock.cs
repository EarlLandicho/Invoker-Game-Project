#region

using UnityEngine;

#endregion

public class DoorLock : MonoBehaviour
{
	[SerializeField] private BattlefieldTrigger battlefieldTrigger;
	[SerializeField] private EnemySpawner enemySpawner;
	private AudioSource audioSource;
	private Animator animator;
	private Collider2D collider2d;

	private void Awake()
	{
		animator = GetComponent<Animator>();
		collider2d = GetComponent<Collider2D>();
		collider2d.enabled = false;
		battlefieldTrigger.PlayerTriggered += LockDoor;
		enemySpawner.EnemiesKilledInBattleField += UnlockDoor;
		audioSource = GameObject.Find("CloseOpenDoor").GetComponent<AudioSource>();
		
	}

	private void LockDoor()
	{
		animator.SetTrigger("lockDoor");
		audioSource.Play();
		Debug.Log(audioSource);
		collider2d.enabled = true;
	}

	private void UnlockDoor()
	{
		animator.SetTrigger("unlockDoor");
		audioSource.Play();
		Debug.Log(audioSource);
		collider2d.enabled = false;
	}
}