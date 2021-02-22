using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthArmorShieldAnimation : MonoBehaviour
{
    [SerializeField] private float spiritRotateSpeed;
    [SerializeField] private float spiritRotationRadius;

    private float spiritRotationAngle = 0;



    void Update()
    {
        spiritRotationAngle += spiritRotateSpeed * Time.deltaTime;
        transform.position = transform.parent.transform.position + new Vector3(Mathf.Sin(spiritRotationAngle / 2), Mathf.Sin(spiritRotationAngle), 0) * spiritRotationRadius;
    }



}
