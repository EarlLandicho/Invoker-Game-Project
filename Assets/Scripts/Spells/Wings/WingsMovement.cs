using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingsMovement : MonoBehaviour
{
    public static float flightDurationTemp;

    [SerializeField] private float flightDuration = 0;
    [SerializeField] private float flightSpeedFactor = 0;

    private IMovement playerMovement;
    private Rigidbody2D playerRigidbody;

    private static WingsMovement instance;

    void Awake()
    {
        //Singleton
        if (instance != null)
        {
            flightDurationTemp = flightDuration;
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        playerMovement = GameObject.Find("Player").GetComponent<IMovement>();
        playerRigidbody = GameObject.Find("Player").GetComponent<Rigidbody2D>();

        playerMovement.SetLockMovement(true);
        playerMovement.SetMovementSpeedByFactor(flightSpeedFactor);

        flightDurationTemp = flightDuration;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            CancelFlight();
        }

        if (flightDurationTemp > 0)
        {
            flightDurationTemp -= Time.deltaTime;
            Fly();
        }
        else
        {
            playerMovement.SetLockMovement(false);
            playerMovement.SetSpeedToDefault();
            Destroy(gameObject);
        }
    }

    public void CancelFlight()
    {
        flightDurationTemp = 0;
    }

    private void Fly()
    {
        playerRigidbody.velocity = new Vector2(Input.GetAxis("Horizontal") * playerMovement.GetMovementSpeed(), playerRigidbody.velocity.y);
        playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, Input.GetAxis("Vertical") * playerMovement.GetMovementSpeed());
    }

}
