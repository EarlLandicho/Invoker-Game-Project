using System.Collections;
using UnityEngine;

public class EarthArmor : MonoBehaviour
{
    [Range(0, 1)]
    [SerializeField] private float percentDamageDecrease = 0;
    [SerializeField] private float duration = 0;
    [SerializeField] private Color armorColor;
    [Range(0, 100)]
    [SerializeField] private float deflectDamagePercent;

    private StatusEffect playerStatusEffect;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        playerStatusEffect = GameObject.Find("Player").GetComponent<StatusEffect>();
        spriteRenderer = GameObject.Find("Player").GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        playerStatusEffect.BecomeArmored(percentDamageDecrease, duration);
        spriteRenderer.color = armorColor;
        StartCoroutine("ArmorDuration");
    }

    private IEnumerator ArmorDuration()
    {
        yield return new WaitForSeconds(duration);
        spriteRenderer.color = Color.white;
        Destroy(gameObject);
    }

    
}