using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenMushroomPoisonAttack : ProjectileAttack
{
    /*
     * number of projectiles
     * spawning length
     * has to be attack animating while spawning projectiles
     * max distance from spawn point for x and y
     * projectile duration
     * random time for lean tween to control speed
     * set stunned animation in animator controller
     * set spawned animation
     */


	[SerializeField] private int numberOfProjectiles;
	[SerializeField] private float spawningDuration;
	[SerializeField] private float maxXDistanceOfProjectile;
	[SerializeField] private float maxYSpeedOfProjectile;
	[SerializeField] private float xTweenTime;
	[SerializeField] private float projectileDuration;

	private new void Update()
	{
		base.Update();
	}
	
	// Called in Animator
	public override void Attack()
	{
		currentProjectile = Instantiate(projectile, projectileLaunchPosition.position, transform.rotation);
		currentProjectile.GetComponent<EnemyProjectile>().SetDamage(damage);
	}

	//Called in Animator
	public void StartSpawning()
	{
		StartCoroutine(SpawnProjectiles());
	}

	private IEnumerator SpawnProjectiles()
	{
		yield return new WaitForSeconds(spawningDuration);
		animator.SetTrigger("doneSpawningProjectiles");
		ResetAttackSpeed();
	}

	
	
	
	
	
}
