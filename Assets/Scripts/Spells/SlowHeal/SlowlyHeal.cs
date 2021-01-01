using System.Collections;
using UnityEngine;

public class SlowlyHeal : MonoBehaviour
{
    [SerializeField] private float healAmount;
    [SerializeField] private float healDuration;

    private IStatusEffect statusEffect;

    private void Awake()
    {
        statusEffect = GameObject.Find("Player").GetComponent<IStatusEffect>();
        statusEffect.Dispel();
        statusEffect.TickHealing(healAmount, healDuration);

        StartCoroutine("DestroyThis");
    }

    private IEnumerator DestroyThis()
    {
        yield return new WaitForSeconds(healDuration);
        Destroy(gameObject);
    }
}