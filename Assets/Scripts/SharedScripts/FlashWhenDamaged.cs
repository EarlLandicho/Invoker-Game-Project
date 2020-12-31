using UnityEngine;

//Hitting object must be layered as "Attack". Must also be a Trigger
[RequireComponent(typeof(SpriteRenderer))]
public class FlashWhenDamaged : MonoBehaviour
{
    [SerializeField] private float flashTime = 0.05f;

    private Color color;
    private Color colorTemp;

    private void Awake()
    {
        color = Color.red;
    }

    //called by IHealth objects
    public void FlashSprite()
    {
        colorTemp = GetComponent<SpriteRenderer>().color;
        GetComponent<SpriteRenderer>().color = color;
        Invoke("ResetColor", flashTime);
    }

    private void ResetColor()
    {
        GetComponent<SpriteRenderer>().color = colorTemp;
    }
}