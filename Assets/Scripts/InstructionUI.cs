using UnityEngine;

public class InstructionUI : MonoBehaviour
{
    private bool instructionIsOpen;
    private GameObject instruction;

    private void Awake()
    {
        GetComponent<InputTools>().InstructionButtonPressed += ShowOrHideInstructions;
        instruction = GameObject.Find("Instructions");
        instructionIsOpen = false;
        instruction.SetActive(false);
    }

    private void OnDestroy()
    {
        //Debug.Log(GetComponent<InputTools>());
        GetComponent<InputTools>().InstructionButtonPressed -= ShowOrHideInstructions;
    }

    private void ShowOrHideInstructions()
    {
        if (!instructionIsOpen)
        {
            instruction.SetActive(true);
            instructionIsOpen = true;
        }
        else
        {
            instruction.SetActive(false);
            instructionIsOpen = false;
        }
    }
}