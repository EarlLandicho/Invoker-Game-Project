using UnityEngine;

public class IcicleLauncher : MonoBehaviour
{
    [SerializeField] private GameObject icicleProjetile;
    [SerializeField] private float launchDelay;
    [SerializeField] private int numberOfProjectiles;
    [SerializeField] private float randomLaunchPositionRadius;

    private float angle;

    private void Awake()
    {
        if (Input.GetKey(KeyCode.W))
        {
            angle = 90;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            angle = -90;
        }

        InvokeRepeating("Launch", 0f, launchDelay);
    }

    private void Launch()
    {
        numberOfProjectiles--;

        Instantiate(icicleProjetile, transform.position + new Vector3(Random.Range(-randomLaunchPositionRadius, randomLaunchPositionRadius), Random.Range(-randomLaunchPositionRadius, randomLaunchPositionRadius) + 0.1f), transform.rotation).GetComponent<IcicleLaunch>().Launch(angle);

        if (numberOfProjectiles <= 0)
        {
            CancelInvoke();
            Destroy(gameObject);
        }
    }
}