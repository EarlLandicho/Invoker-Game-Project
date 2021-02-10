using Cinemachine;
using UnityEngine;


public class VirtualCameraBlendController : MonoBehaviour
{
    [SerializeField] private BattlefieldTrigger battlefieldTrigger;
    private CinemachineVirtualCamera virtualCamera;

    void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        battlefieldTrigger.PlayerTriggered += SwitchCamera;
    }

    private void Start()
    {
        virtualCamera.Priority = 0;
    }

    private void SwitchCamera()
    {
        virtualCamera.Priority = 100;
    }

}