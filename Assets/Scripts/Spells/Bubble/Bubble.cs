using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public static float bubbleDurationTemp;

    [SerializeField] private float bubbleDuration = 0;
    [SerializeField] private float movementSpeedFactor = 0;

    private IStatusEffect playerStatusEffect;
    private IMovement playerMovement;

    private static Bubble instance;

    void Awake()
    {
        //Singleton
        if (instance != null)
        {
            bubbleDurationTemp = bubbleDuration;
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        playerStatusEffect = GameObject.Find("Player").GetComponent<IStatusEffect>();
        playerMovement = GameObject.Find("Player").GetComponent<IMovement>();

        playerStatusEffect.BecomeStatusEffectImmune(true);
        playerStatusEffect.Dispel();
        playerMovement.SetMovementSpeedByFactor(movementSpeedFactor);

        bubbleDurationTemp = bubbleDuration;
    }

    void Update()
    {
        if (bubbleDurationTemp > 0)
        {
            bubbleDurationTemp -= Time.deltaTime;
        }
        else
        {
            playerStatusEffect.BecomeStatusEffectImmune(false);
            playerMovement.SetSpeedToDefault();

            Destroy(gameObject);
        }
    }

}
