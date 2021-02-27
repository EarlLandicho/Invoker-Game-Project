using UnityEngine;

public class ButtonOpenDoor : MonoBehaviour, IButton
{
    [SerializeField] private GameObject door;

    public void ActivateButton()
    {
        door.GetComponent<CloseAndOpenDoor>().OpenDoor();
    }
}