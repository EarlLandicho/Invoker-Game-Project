using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class LaunchKinematicObject : MonoBehaviour
{
    [SerializeField] private float speed = 0;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = transform.up * speed;
            var rotationVector = transform.rotation.eulerAngles;
            rotationVector.z = 90;
            transform.rotation = Quaternion.Euler(rotationVector); 
            
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = -transform.up * speed;
            var rotationVector = transform.rotation.eulerAngles;
            rotationVector.z = -90;
            transform.rotation = Quaternion.Euler(rotationVector);

        }
        else
        {

            rb.velocity = transform.right * speed;
        }
    }
}
