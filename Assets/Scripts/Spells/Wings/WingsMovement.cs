using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingsMovement : MonoBehaviour
{
    [SerializeField] private float flightDuration = 0;
    [SerializeField] private float flightSpeedFactor = 0;

    private IMovement playerMovement;
    private Rigidbody2D playerRigidbody;
    private float flightDurationTemp;


    void Awake()
    {
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
            return;
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
