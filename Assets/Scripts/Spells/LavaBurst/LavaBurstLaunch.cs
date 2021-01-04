using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaBurstLaunch : MonoBehaviour
{
    [SerializeField] private GameObject projectile;

    void Awake()
    {
        //up right
        Instantiate(projectile, transform.position, transform.rotation).GetComponent<Rigidbody2D>().AddForce(new Vector2(100, 150));
        //up left
        Instantiate(projectile, transform.position, transform.rotation).GetComponent<Rigidbody2D>().AddForce(new Vector2(-100, 150));

        //up
        Instantiate(projectile, transform.position, transform.rotation).GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 200));

        //down right
        Instantiate(projectile, transform.position, transform.rotation).GetComponent<Rigidbody2D>().AddForce(new Vector2(100, -100));
        //down left
        Instantiate(projectile, transform.position, transform.rotation).GetComponent<Rigidbody2D>().AddForce(new Vector2(-100, -100));

        //right
        Instantiate(projectile, transform.position, transform.rotation).GetComponent<Rigidbody2D>().AddForce(new Vector2(200, 10));
        //left
        Instantiate(projectile, transform.position, transform.rotation).GetComponent<Rigidbody2D>().AddForce(new Vector2(-200, 10));
    }



}
