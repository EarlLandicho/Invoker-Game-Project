using System;
using UnityEngine;
using EasyFeedback;

public class SpiritInput : MonoBehaviour
{
    public event Action InvokeSpiritsButtonPressed = delegate { };

    public event Action<int> SpiritsActivateButtonPressed = delegate { };

    public event Action ClearSpiritsButtonPressed = delegate { };

    //Used by animation spirit rotation
    public event Action UpdateSpiritAnimation = delegate { };

    private void Update()
    {
        if (!FeedbackForm.formIsOpened)
        {
            InputCheck();
        }
    }

    private void InputCheck()
    {
        //SpiritsEnqueued event has 1, 2, 3 as inputs for spirit1, spirit2, spirit3 respectively
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SpiritsActivateButtonPressed(1);
            UpdateSpiritAnimation();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            SpiritsActivateButtonPressed(2);
            UpdateSpiritAnimation();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SpiritsActivateButtonPressed(3);
            UpdateSpiritAnimation();
        }
        else if (Input.GetKeyDown(KeyCode.RightControl))
        {
            ClearSpiritsButtonPressed();
            UpdateSpiritAnimation();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            InvokeSpiritsButtonPressed();
            UpdateSpiritAnimation();
        }
    }
}