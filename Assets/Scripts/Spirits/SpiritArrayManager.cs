using UnityEngine;
using UnityEngine.SceneManagement;

public class SpiritArrayManager : MonoBehaviour
{
    [SerializeField] private int spiritStartingAmount1 = 3;
    [SerializeField] private int spiritStartingAmount2 = 3;
    [SerializeField] private int spiritStartingAmount3 = 3;

    private int spiritMaxAmount1;
    private int spiritMaxAmount2;
    private int spiritMaxAmount3;

    //Used by SpiritRotateAroundPlayerAnimation, SpiritAnimationSelector and SpiritUI
    private int[] spiritArray = new int[] { 0, 0, 0 };

    private int spiritCurrentAmount1;
    private int spiritCurrentAmount2;
    private int spiritCurrentAmount3;
    private int spiritIndex = 0;
    private SpiritInput spiritInput;
    private SpiritCast spiritCast;


    private static SpiritArrayManager instance = null;


    private void Awake()
    {
        //Singleton
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);


        spiritMaxAmount1 = spiritStartingAmount1;
        spiritMaxAmount2 = spiritStartingAmount2;
        spiritMaxAmount3 = spiritStartingAmount3;

        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;



    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            spiritMaxAmount1 = spiritStartingAmount1;
            spiritMaxAmount2 = spiritStartingAmount2;
            spiritMaxAmount3 = spiritStartingAmount3;
            ClearSpirits();

            return; //return so we dont have to rewire references
        }

        spiritInput = GameObject.Find("Spirits").GetComponent<SpiritInput>();
        spiritCast = GameObject.Find("Spirits").GetComponent<SpiritCast>();

        spiritInput.SpiritsActivateButtonPressed += ActivateSpirit;
        spiritInput.ClearSpiritsButtonPressed += ClearSpirits;
        spiritCast.SpiritsHaveBeenCasted += ClearSpirits;

        spiritCurrentAmount1 = spiritMaxAmount1;
        spiritCurrentAmount2 = spiritMaxAmount2;
        spiritCurrentAmount3 = spiritMaxAmount3;

    }
    private void OnSceneUnloaded(Scene scene)
    {
        spiritInput.SpiritsActivateButtonPressed -= ActivateSpirit;
        spiritInput.ClearSpiritsButtonPressed -= ClearSpirits;
        spiritCast.SpiritsHaveBeenCasted -= ClearSpirits;

        
    }

    public int[] GetSpiritArray()
    {
        return spiritArray;
    }

    public int GetSpiritCurrentAmount(int spiritNumber)
    {
        switch (spiritNumber)
        {
            case 1:
                return spiritCurrentAmount1;

            case 2:
                return spiritCurrentAmount2;

            case 3:
                return spiritCurrentAmount3;

            default:
                return 0;
        }
    }

    public int GetSpiritMaxAmount(int spiritNumber)
    {
        switch (spiritNumber)
        {
            case 1:
                return spiritMaxAmount1;

            case 2:
                return spiritMaxAmount2;

            case 3:
                return spiritMaxAmount3;

            default:
                return 0;
        }
    }

    public void IncrementSpiritCurrentAmount(int spiritNumber)
    {
        switch (spiritNumber)
        {
            case 1:
                spiritCurrentAmount1++;
                break;

            case 2:
                spiritCurrentAmount2++;
                break;

            case 3:
                spiritCurrentAmount3++;
                break;
        }
    }

    public void DecrementSpiritCurrentAmount(int spiritNumber)
    {
        switch (spiritNumber)
        {
            case 1:
                spiritCurrentAmount1--;
                break;

            case 2:
                spiritCurrentAmount2--;
                break;

            case 3:
                spiritCurrentAmount3--;
                break;
        }
    }

    public void IncrementSpiritMaxAmount(int spiritNumber)
    {
        switch (spiritNumber)
        {
            case 1:
                spiritMaxAmount1++;
                break;

            case 2:
                spiritMaxAmount2++;
                break;

            case 3:
                spiritMaxAmount3++;
                break;
        }
    }

    private void ClearSpirits()
    {
        spiritArray[0] = 0;
        spiritArray[1] = 0;
        spiritArray[2] = 0;
    }

    //Puts spirits in the array. Will loop around the array. Will not put spirits if spirits are in cooldown.
    private void ActivateSpirit(int spiritNum)
    {

        int count = 0;
        if (spiritNum == 1 && spiritCurrentAmount1 > 0)
        {
            foreach (int num in spiritArray)
            {
                if (num == 1)
                {
                    count++;
                }
            }

            if (count < spiritCurrentAmount1)
            {
                spiritArray[spiritIndex] = spiritNum;
                IncrementArrayIndex();
            }
        }
        else if (spiritNum == 2 && spiritCurrentAmount2 > 0)
        {
            foreach (int num in spiritArray)
            {
                if (num == 2)
                {
                    count++;
                }
            }

            if (count < spiritCurrentAmount2)
            {
                spiritArray[spiritIndex] = spiritNum;
                IncrementArrayIndex();
            }
        }
        else if (spiritNum == 3 && spiritCurrentAmount3 > 0)
        {
            foreach (int num in spiritArray)
            {
                if (num == 3)
                {
                    count++;
                }
            }

            if (count < spiritCurrentAmount3)
            {
                spiritArray[spiritIndex] = spiritNum;
                IncrementArrayIndex();
            }
        }
        //PrintSpiritArray();
    }

    private void IncrementArrayIndex()
    {
        spiritIndex++;
        if (spiritIndex >= 3)
        {
            spiritIndex = 0;
        }
    }

    private void PrintSpiritArray()
    {
        Debug.LogFormat("Current Array: [ {0}, {1}, {2} ]", spiritArray[0], spiritArray[1], spiritArray[2]);
    }

    private void PrintCurrentSpiritAmount()
    {
        Debug.LogFormat("Current Amount: spirit1 {0}, spirit2 {1}, spirit3 {2}", spiritCurrentAmount1, spiritCurrentAmount2, spiritCurrentAmount3);
    }
}