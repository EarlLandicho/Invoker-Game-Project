using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOpenDoor : MonoBehaviour, IButton
{
    [SerializeField] GameObject door;

    public void ActivateButton()
    {
        //Throws an error
        door.GetComponent<CloseAndOpenDoor>().OpenDoor();
        
    }
}
