using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HibernateImmobilize : MonoBehaviour
{

    private IMovement playerMovement;
    private IHealth playerHealth;

    void Awake()
    {
        playerMovement = GameObject.Find("Player").GetComponent<IMovement>();
        playerHealth = GameObject.Find("Player").GetComponent<IHealth>();

        playerHealth.SetIsInvulnerable(true);
        playerMovement.SetLockMovement(true);
    }

    void OnDestroy()
    {
        playerHealth.SetIsInvulnerable(false);
        playerMovement.SetLockMovement(false);
    }




}
