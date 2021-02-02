using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CompositeCollider2D))]
public class TileJumpDown : MonoBehaviour
{

    private CompositeCollider2D compositeCollider;
    private float reverseCollisionTimer = .1f;

    private float reverseCollisionTimerTemp;
    private bool reverseDelay;

    void Awake()
    {
        compositeCollider = GetComponent<CompositeCollider2D>();
        reverseCollisionTimerTemp = reverseCollisionTimer;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.S))
        {
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Ledge"));
            compositeCollider.usedByEffector = false;

        }
        else if(Input.GetKeyUp(KeyCode.S))
        {
            reverseDelay = true;

        }


        if(reverseDelay)
        {
            if (reverseCollisionTimerTemp > 0)
            {
                reverseCollisionTimerTemp -= Time.deltaTime;
            }
            else
            {
                reverseCollisionTimerTemp = reverseCollisionTimer;
                Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Ledge"), false);
                compositeCollider.usedByEffector = true;
                reverseDelay = false;

            }
        }
    }





}
