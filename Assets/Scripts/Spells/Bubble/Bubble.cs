using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public static float bubbleDurationTemp;

    [SerializeField] private float bubbleDuration = 0;
    [SerializeField] private float movementSpeedFactor = 0;

    private StatusEffect playerStatusEffect;

    private static Bubble instance;

    void Awake()
    {
        playerStatusEffect = GameObject.Find("Player").GetComponent<StatusEffect>();

        //Singleton
        if (instance != null)
        {
            playerStatusEffect.BecomeBubbled(movementSpeedFactor, bubbleDuration);
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        

        playerStatusEffect.BecomeStatusEffectImmune(bubbleDuration);
        playerStatusEffect.BecomeBubbled(movementSpeedFactor, bubbleDuration);

        bubbleDurationTemp = bubbleDuration;

        Destroy(gameObject, bubbleDuration);
    }


}
