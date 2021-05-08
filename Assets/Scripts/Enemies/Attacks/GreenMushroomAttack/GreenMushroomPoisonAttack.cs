using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GreenMushroomPoisonAttack : ProjectileAttack
{
	[SerializeField] private int numberOfProjectiles;
	[SerializeField] private float spawningDuration;
	[SerializeField] private float maxXDistanceOfProjectile;
	[SerializeField] private float minYSpeedOfProjectile;
	[SerializeField] private float maxYSpeedOfProjectile;
	[SerializeField] private float xTweenTime;
	[SerializeField] private float projectileDuration;

	private int numberOfProjectileSpawned = 0;
	private new void Update()
	{
		base.Update();
	}
	

	//Called in Animator
	public void StartSpawning()
	{
		StartCoroutine(SpawnProjectilesCoroutine());
	}

	private IEnumerator SpawnProjectilesCoroutine()
	{
		float spawnRate = spawningDuration / numberOfProjectiles;
		
		InvokeRepeating(nameof(SpawnProjectiles), 0, spawnRate);


		yield return new WaitForSeconds(spawningDuration);
		animator.SetTrigger("doneSpawningProjectiles");
		numberOfProjectileSpawned = 0;
		CancelInvoke();
		ResetAttackSpeed();
	}

	private void SpawnProjectiles()
	{
		if (isLockedAttack)
		{
			CancelInvoke();
		}
		
		if (numberOfProjectileSpawned < numberOfProjectiles)
		{
			float randomXDistanceOfProjectile = Random.Range(0f, maxXDistanceOfProjectile);
			bool willLaunchRight = Random.value < 0.5f;
			bool willFlipSprite = Random.value < 0.5f;
			float randomYSpeed = Random.Range(minYSpeedOfProjectile, maxYSpeedOfProjectile);
			FloatingProjectile proj = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<FloatingProjectile>();

			proj.SetXTweenDistance(randomXDistanceOfProjectile);
			proj.SetIsFacingRight(willFlipSprite);
			proj.SetIsLaunchingRight(willLaunchRight);
			proj.SetXTweenTime(xTweenTime);
			proj.SetYSpeed(randomYSpeed);
			proj.SetFloatDuration(projectileDuration);
			proj.SetDamage(damage);
			
			numberOfProjectileSpawned++;
		}
		
	}
}
