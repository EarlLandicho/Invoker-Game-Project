using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class VirtualCameraBlendController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    private void Start()
    {
        virtualCamera.Priority = 0;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            virtualCamera.Priority = 100;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            virtualCamera.Priority = 0;
        }
    }
}