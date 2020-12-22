using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(BoxCollider2D))]
public class VirtualCameraBlendController : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera virtualCamera;

    void Start()
    {
        virtualCamera.Priority = 0;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            virtualCamera.Priority = 100;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            virtualCamera.Priority = 0;
        }
    }

}
