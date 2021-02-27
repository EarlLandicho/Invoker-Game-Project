using UnityEngine;

public class FireSpiritDuration : MonoBehaviour
{
    [SerializeField] private float duration;

    private float durationTemp;

    private void Awake()
    {
        durationTemp = duration;
    }

    private void Update()
    {
        if (durationTemp > 0)
        {
            durationTemp -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}