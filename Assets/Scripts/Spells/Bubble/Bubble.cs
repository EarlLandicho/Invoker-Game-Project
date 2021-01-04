using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] private float duration = 0;
    [SerializeField] private float movementSpeedFactor = 0;

    private IStatusEffect playerStatusEffect;
    private IMovement playerMovement;

    void Awake()
    {
        playerStatusEffect = GameObject.Find("Player").GetComponent<IStatusEffect>();
        playerMovement = GameObject.Find("Player").GetComponent<IMovement>();

        playerStatusEffect.BecomeStatusEffectImmune(true);
        playerStatusEffect.Dispel();
        playerMovement.SetMovementSpeedByFactor(movementSpeedFactor);


        StartCoroutine("SpellLifeTime");
    }

    private IEnumerator SpellLifeTime()
    {
        yield return new WaitForSeconds(duration);

        playerStatusEffect.BecomeStatusEffectImmune(false);
        playerMovement.SetSpeedToDefault();

        Destroy(gameObject);
    }


}
