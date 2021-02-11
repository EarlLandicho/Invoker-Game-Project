using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleProjectileAttack : ProjectileAttack
{
    [SerializeField] private Transform[] projectileLaunchPositions;
    [SerializeField] private float launchDirecitonAngleRandomness;
    

    // Called in Animator
    public override void Attack()
    {
        foreach(Transform position in projectileLaunchPositions)
        {
            float randomAngle = Random.Range(-launchDirecitonAngleRandomness / 2, launchDirecitonAngleRandomness / 2);
            currentProjectile = Instantiate(projectile, position.position, transform.rotation);
            currentProjectile.GetComponent<EnemyProjectile>().SetDamage(damage);
            currentProjectile.GetComponent<EnemyProjectile>().SetPlayerDirection((Quaternion.AngleAxis(randomAngle, Vector3.forward) * ExtensionMethods.GetNormalizedDirectionToPlayer2D(gameObject)).normalized);
            currentProjectile.GetComponent<EnemyProjectile>().SetProjectileSpeed(projectileSpeed);
            currentProjectile.GetComponent<EnemyProjectile>().Launch();

        }
    }



}
