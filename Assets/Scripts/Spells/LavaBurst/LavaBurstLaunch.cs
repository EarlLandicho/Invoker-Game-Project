using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaBurstLaunch : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private int numberofProjectiles;
    [SerializeField] private float projectileForce;

    void Awake()
    {
        ////up right
        //Instantiate(projectile, transform.position, transform.rotation).GetComponent<Rigidbody2D>().AddForce(new Vector2(100, 150));
        ////up left
        //Instantiate(projectile, transform.position, transform.rotation).GetComponent<Rigidbody2D>().AddForce(new Vector2(-100, 150));

        ////up
        //Instantiate(projectile, transform.position, transform.rotation).GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 200));

        ////down right
        //Instantiate(projectile, transform.position, transform.rotation).GetComponent<Rigidbody2D>().AddForce(new Vector2(100, -100));
        ////down left
        //Instantiate(projectile, transform.position, transform.rotation).GetComponent<Rigidbody2D>().AddForce(new Vector2(-100, -100));

        ////right
        //Instantiate(projectile, transform.position, transform.rotation).GetComponent<Rigidbody2D>().AddForce(new Vector2(200, 10));
        ////left
        //Instantiate(projectile, transform.position, transform.rotation).GetComponent<Rigidbody2D>().AddForce(new Vector2(-200, 10));

        for(int i = 0; i < numberofProjectiles; i++)
        {
            Instantiate(projectile, transform.position, transform.rotation).GetComponent<Rigidbody2D>().AddForce((Quaternion.AngleAxis((360 / numberofProjectiles) * i, Vector3.forward).normalized * new Vector2(projectileForce, 0)));
        }
    }



}
