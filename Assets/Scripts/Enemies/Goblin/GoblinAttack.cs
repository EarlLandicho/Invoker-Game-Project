using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class GoblinAttack : MonoBehaviour, IEnemyAttack
{
    [SerializeField] float damage = 0;
    [SerializeField] float attackDelay = 1;
    private BoxCollider2D boxCollider;
    private EnemyPatrol enemyPatrol;
    private Rigidbody2D rb;
    private bool isFacingRight = true;
    private bool readyToAttack;
    private bool playerInSight;

    void Awake()
    {
        boxCollider = transform.Find("EnemyAttackRange").GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        if (GetComponent<EnemyPatrol>() != null)
        {
            enemyPatrol = GetComponent<EnemyPatrol>();
        }

    }

    void Update()
    {
        //keeps attacking when player stays in line of sight
        if(playerInSight && readyToAttack)
        {
            readyToAttack = false;
            StartCoroutine("MeleeAttack");
        }
    }
    //only called once upon enter
    public void Attack(GameObject player)
    {
        playerInSight = true;
        readyToAttack = true;
        OffSetCheck();
        StopHere();
        DisablePatrol();
        
    }

    public void OutOfAttackRange()
    {
        playerInSight = false;
        EnablePatrol();
    }

    private IEnumerator MeleeAttack()
    {
        yield return new WaitForSeconds(attackDelay);
        Vector2 boxColliderPosition;
        //gives the correct offset to the overlapbox. Compensates for the turning of the sprite
        if (isFacingRight)
        {
            boxColliderPosition = (Vector2)transform.position + boxCollider.offset;
        }
        else
        {
            boxColliderPosition = (Vector2)transform.position - boxCollider.offset;
        }
        
        Collider2D player = Physics2D.OverlapBox(boxColliderPosition, boxCollider.size, 0, 1 << LayerMask.NameToLayer("Player"));
        if(player != null)
        {
            player.gameObject.GetComponent<IHealth>().TakeDamage(damage);
        }

        //enemy is ready to attack again
        readyToAttack = true;
        

    }

    private void OffSetCheck()
    {
        if(GetComponent<Rigidbody2D>().velocity.x > 0.1f)
        {
            isFacingRight = true;
        }
        else if(GetComponent<Rigidbody2D>().velocity.x < -0.1f)
        {
            isFacingRight = false;
            
        }
    }

    private void DisablePatrol()
    {
        if (enemyPatrol != null)
        {
            enemyPatrol.enabled = false;
        }
    }

    private void EnablePatrol()
    {
        if (enemyPatrol != null)
        {
            enemyPatrol.enabled = true;
        }
    }

    private void StopHere()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
    }
    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.DrawCube(boxCollider.offset + (Vector2)transform.position, boxCollider.size);
    //}
}
