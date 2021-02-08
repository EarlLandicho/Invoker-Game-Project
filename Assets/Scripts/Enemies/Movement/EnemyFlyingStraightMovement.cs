using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlyingStraightMovement : EnemyMovement
{
    [SerializeField] private Transform wallCheck;
    [SerializeField] private Transform upperWallCheck;
    [SerializeField] private Transform lowerWallCheck;


    private Vector2 targetToMoveTo;


    protected override void Awake()
    {
        base.Awake();
    }

    void Update()
    {
        WallCheck();
        UpperWallCheck();
        LowerWallCheck();
        if(!isXMovementSpeedLocked)
        {
            
            rb.velocity = targetToMoveTo * movementSpeed;
        }
        

    }



    // Called in Animator
    public void MovementCheck()
    {
        targetToMoveTo = ExtensionMethods.GetNormalizedDirectionToPlayer2D(gameObject);
    }


    public override void SetLockXMovement(bool isLocked)
    {
        isXMovementSpeedLocked = isLocked;
        if (isLocked)
        {
            rb.velocity = new Vector2(0, 0);
        }
        else
        {
            movementSpeed = movementSpeedTemp * movementSpeedModifier;
        }
    }

    private void WallCheck()
    {
        if (Physics2D.OverlapCircle(new Vector2(wallCheck.position.x, wallCheck.position.y), 0.03f, 1 << LayerMask.NameToLayer("Ground")))
        {
            targetToMoveTo = Vector2.right;
        }
    }

    private void UpperWallCheck()
    {
        if (Physics2D.OverlapCircle(new Vector2(upperWallCheck.position.x, upperWallCheck.position.y), 0.03f, 1 << LayerMask.NameToLayer("Ground")))
        {
            targetToMoveTo = Vector2.down;
        }
    }

    private void LowerWallCheck()
    {
        if (Physics2D.OverlapCircle(new Vector2(lowerWallCheck.position.x, lowerWallCheck.position.y), 0.03f, 1 << LayerMask.NameToLayer("Ground")))
        {
            targetToMoveTo = Vector2.up;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(wallCheck.position, 0.03f);
        Gizmos.DrawWireSphere(upperWallCheck.position, 0.03f);
        Gizmos.DrawWireSphere(lowerWallCheck.position, 0.03f);
    }



}
