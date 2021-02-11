using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboBar : MonoBehaviour
{
    public static float currentBarLevel;
    public static int comboBarStage;

    [SerializeField] private float comboLevelDrainFactor = 1;

    void Awake()
    {
        currentBarLevel = 0;
    }

    void Update()
    {
        DrainBarLevel();
        BarLevelMaxReachedCheck();
        ComboBarStageCheck();
    }

    private void ComboBarStageCheck()
    {
        if (ExtensionMethods.IsBetweenTwoValues(0f, 25f, currentBarLevel))
        {
            comboBarStage = 1;
        }
        else if (ExtensionMethods.IsBetweenTwoValues(25f, 50f, currentBarLevel))
        {
            comboBarStage = 2;
        }
        else if (ExtensionMethods.IsBetweenTwoValues(50f, 75f, currentBarLevel))
        {
            comboBarStage = 3;
        }
        else if (ExtensionMethods.IsBetweenTwoValues(75f, 101f, currentBarLevel))
        {
            comboBarStage = 4;
        }

    }

    private void DrainBarLevel()
    {
        if (currentBarLevel > 0)
        {
            currentBarLevel -= Time.deltaTime * comboLevelDrainFactor;
        }
    }

    private void BarLevelMaxReachedCheck()
    {
        if (currentBarLevel > 100)
        {
            currentBarLevel = 100;
        }
    }
}
