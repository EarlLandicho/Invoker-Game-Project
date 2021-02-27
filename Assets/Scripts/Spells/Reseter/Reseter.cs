using UnityEngine;

public class Reseter : MonoBehaviour
{
    private SpiritCast spiritCast;

    private void Awake()
    {
        spiritCast = (SpiritCast)GameObject.FindObjectOfType(typeof(SpiritCast));

        spiritCast.ResetAllCooldowns();
    }
}