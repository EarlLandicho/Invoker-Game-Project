using UnityEngine;

public class Reseter : MonoBehaviour
{
    [SerializeField] private GameObject reseterAnimation;
    private SpiritCast spiritCast;

    private void Awake()
    {
        spiritCast = (SpiritCast)GameObject.FindObjectOfType(typeof(SpiritCast));

        // This must be in Awake to work
        spiritCast.ResetAllCooldowns();
    }

    private void Start()
    {
        Instantiate(reseterAnimation, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}