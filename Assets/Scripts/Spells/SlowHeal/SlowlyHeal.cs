using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowlyHeal : MonoBehaviour
{
    [SerializeField] private float healAmount;
    [SerializeField] private float healDuration;

    private StatusEffect statusEffect;

    void Awake()
    {
        statusEffect = GameObject.Find("Player").GetComponent<StatusEffect>();
        statusEffect.TickHealing(healAmount, healDuration);

        StartCoroutine("DestroyThis");
    }

    private IEnumerator DestroyThis()
    {
        yield return new WaitForSeconds(healDuration);
        Destroy(gameObject);
    }


}
