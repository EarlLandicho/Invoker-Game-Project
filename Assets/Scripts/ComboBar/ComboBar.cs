using UnityEngine;

public class ComboBar : MonoBehaviour
{
    public static float currentBarLevel;
    public static int comboBarStage;

    [SerializeField] private float comboLevelDrainFactor = 1;

    private void Awake()
    {
        currentBarLevel = 0;
    }

    private void Update()
    {
        DrainBarLevel();
        BarLevelMaxReachedCheck();
        ComboBarStageCheck();
    }

    private void ComboBarStageCheck()
    {
        if (currentBarLevel < 25f)
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
        else if (currentBarLevel >= 75f)
        {
            comboBarStage = 4;
        }
        else
        {
            Debug.LogError("Something wrong with the stages in the combo bar");
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