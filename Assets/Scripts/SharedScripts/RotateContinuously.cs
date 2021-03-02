using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateContinuously : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 1;
    [SerializeField] private bool clockWise;


    void Update()
    {
        if(!clockWise)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
        }
        else
        {
            transform.Rotate(-Vector3.up * Time.deltaTime * rotationSpeed);
        }

    }
}
