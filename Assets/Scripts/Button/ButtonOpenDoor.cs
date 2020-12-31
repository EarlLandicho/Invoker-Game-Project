using UnityEngine;

public class ButtonOpenDoor : MonoBehaviour, IButton
{
    [SerializeField] private GameObject door;

    public void ActivateButton()
    {
        //Throws an error
        door.GetComponent<CloseAndOpenDoor>().OpenDoor();
    }
}