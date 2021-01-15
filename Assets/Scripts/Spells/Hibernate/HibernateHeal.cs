using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HibernateHeal : MonoBehaviour
{
    [SerializeField] private float healPerSec = 0;
    private IHealth playerHealth;

    //SUGGESTION: Move to StatusEffect functionality
    void Awake()
    {
        playerHealth = GameObject.Find("Player").GetComponent<IHealth>();

        InvokeRepeating("HibernateTickHealing", 0, Constants.HealTickPerSecond);

    }


    private void HibernateTickHealing()
    {
        playerHealth.TakeHealing(healPerSec * Constants.HealTickPerSecond);
    }

    void OnDestroy()
    {
        CancelInvoke("HibernateTickHealing");
    }

}
