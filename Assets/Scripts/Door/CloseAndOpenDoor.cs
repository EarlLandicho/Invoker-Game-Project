using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CloseAndOpenDoor : MonoBehaviour
{
    [SerializeField] private bool isOpen;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    //used by buttons
    public void OpenDoor()
    {
        isOpen = true;
        animator.SetBool("isOpen", isOpen);
    }

    public void CloseDoor()
    {
        isOpen = false;
        animator.SetBool("isOpen", isOpen);
    }

    public bool GetDoorOpenCloseState()
    {
        return isOpen;
    }
}