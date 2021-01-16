using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingsMovement : MonoBehaviour
{
    public static float flightDurationTemp;

    [SerializeField] private float flightDuration = 0;
    [SerializeField] private float flightSpeedFactor = 0;

    private PlayerMovement playerMovement;

    private static WingsMovement instance;

    void Awake()
    {
        //Singleton
        if (instance != null)
        {
            //reset duration here
            flightDurationTemp = flightDuration;

            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();

        playerMovement.SetMovementSpeedByFactor(flightSpeedFactor, true);
        playerMovement.SetIsFlying(true);

        flightDurationTemp = flightDuration;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            CancelFlight();
            Destroy(gameObject);
        }

        if (flightDurationTemp > 0)
        {
            flightDurationTemp -= Time.deltaTime;
            
        }
        else
        {
            CancelFlight();
            Destroy(gameObject);
        }
    }

    public void CancelFlight()
    {
        playerMovement.SetMovementSpeedByFactor(flightSpeedFactor, false);
        playerMovement.SetIsFlying(false);
    }



}
