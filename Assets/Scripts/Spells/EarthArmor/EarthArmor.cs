using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthArmor : MonoBehaviour
{
    [Range(0, 100)]
    [SerializeField] private float percentDamageDecrease = 0;
    [SerializeField] private float duration = 0;
    [SerializeField] private Color armorColor;
    private PlayerHealth playerHealth;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        spriteRenderer = GameObject.Find("Player").GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        playerHealth.EarthArmorModifier(1 - percentDamageDecrease * 0.01f);
        StartCoroutine("ArmorDuration");
    }

    private IEnumerator ArmorDuration()
    {
        spriteRenderer.color = armorColor;
        yield return new WaitForSeconds(duration);
        playerHealth.ResetDamageModifier();
        spriteRenderer.color = Color.white;
        Destroy(gameObject);
    }

}
