using System.Collections;
using UnityEngine;

public class EarthArmor : MonoBehaviour
{
    [Range(0, 1)]
    [SerializeField] private float percentDamageDecrease = 0;
    [SerializeField] private float duration = 0;

    private StatusEffect playerStatusEffect;

    private void Awake()
    {
        playerStatusEffect = GameObject.Find("Player").GetComponent<StatusEffect>();
    }

    private void Start()
    {
        playerStatusEffect.BecomeArmored(percentDamageDecrease, duration);
        StartCoroutine("ArmorDuration");
    }

    private IEnumerator ArmorDuration()
    {
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }

    
}