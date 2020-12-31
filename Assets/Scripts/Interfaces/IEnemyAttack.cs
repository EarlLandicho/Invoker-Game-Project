using UnityEngine;

public interface IEnemyAttack
{
    void Attack(GameObject player);

    void OutOfAttackRange();
}