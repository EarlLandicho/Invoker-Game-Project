using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TileJumpDown : MonoBehaviour
{

    private PlatformEffector2D effector;
    private float reverseCollisionTimer = .1f;

    private float reverseCollisionTimerTemp;
    private bool reverseDelay;

    void Awake()
    {
        effector = GetComponent<PlatformEffector2D>();
        reverseCollisionTimerTemp = reverseCollisionTimer;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.S))
        {
            effector.rotationalOffset = 180f;

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
                effector.rotationalOffset = 0f;
                reverseDelay = false;

            }
        }
        
    }





}
