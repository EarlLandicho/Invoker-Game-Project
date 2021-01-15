using System.Collections;
using UnityEngine;

public class EarthArmor : MonoBehaviour
{
    [Range(0, 100)]
    [SerializeField] private float percentDamageDecrease = 0;
    [SerializeField] private float duration = 0;
    [SerializeField] private Color armorColor;
    [Range(0, 100)]
    [SerializeField] private float deflectDamagePercent;

    private PlayerHealth playerHealth;
    private SpriteRenderer spriteRenderer;
    private float modifier;

    private void Awake()
    {
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        spriteRenderer = GameObject.Find("Player").GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        modifier = 1 - percentDamageDecrease * 0.01f;
        playerHealth.SetDamageModifier(playerHealth.GetDamageModifier() * modifier);
        playerHealth.SetIsEarthArmored(true);
        spriteRenderer.color = armorColor;
        StartCoroutine("ArmorDuration");
    }

    void Update()
    {
        playerHealth.SetIsEarthArmored(true);
    }

    private IEnumerator ArmorDuration()
    {
        yield return new WaitForSeconds(duration);
        playerHealth.SetDamageModifier(playerHealth.GetDamageModifier() / modifier);
        playerHealth.SetIsEarthArmored(false);
        spriteRenderer.color = Color.white;
        Destroy(gameObject);
        
        
    }

    
}