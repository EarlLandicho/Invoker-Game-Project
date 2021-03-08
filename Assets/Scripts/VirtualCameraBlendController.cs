#region

using Cinemachine;
using UnityEngine;

#endregion

public class VirtualCameraBlendController : MonoBehaviour
{
	[SerializeField] private BattlefieldTrigger battlefieldTrigger;
	private CinemachineVirtualCamera virtualCamera;

	private void Awake()
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