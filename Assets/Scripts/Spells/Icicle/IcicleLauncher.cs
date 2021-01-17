using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcicleLauncher : MonoBehaviour
{
    [SerializeField] GameObject icicleProjetile;
    [SerializeField] float launchDelay;
    [SerializeField] int numberOfProjectiles;
    [SerializeField] float randomLaunchPositionRadius;

    private float angle;

    void Awake()
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

        Instantiate(icicleProjetile, transform.position + new Vector3(Random.Range(-randomLaunchPositionRadius, randomLaunchPositionRadius) , Random.Range(-randomLaunchPositionRadius, randomLaunchPositionRadius)), transform.rotation).GetComponent<IcicleLaunch>().Launch(angle);

        if(numberOfProjectiles <= 0)
        {
            CancelInvoke();
            Destroy(gameObject);
        }
    }



}
