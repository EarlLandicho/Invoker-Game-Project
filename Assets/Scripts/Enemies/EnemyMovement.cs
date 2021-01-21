using System.Collections;
using UnityEngine;

public class EnemyMovement : Movement
{
    protected GameObject playerObject;

    protected new void Awake()
    {
        base.Awake();
        playerObject = GameObject.Find("Player");
        

    }

    protected bool PlayerIsFacingRight()
    {
        if (playerObject.transform.position.x - transform.position.x < 0)
        {
            return false;
        }

        return true;
    }



}