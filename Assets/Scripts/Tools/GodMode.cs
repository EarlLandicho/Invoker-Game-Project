using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GodMode : MonoBehaviour
{
    private bool isGodeMode = false;

    void Awake()
    {
        GetComponent<InputTools>().GodModeActivated += ActivateGodMode;
    }

    void OnDestroy()
    {
        GetComponent<InputTools>().GodModeActivated -= ActivateGodMode;
    }

    private void ActivateGodMode()
    {
        if(!isGodeMode)
        {
            isGodeMode = true;
            GameObject.Find("Player").GetComponent<PlayerHealth>().SetGodModeHealth();
            GameObject.Find("Player").GetComponent<SpriteRenderer>().color = Color.black;

        }
        else
        {
            isGodeMode = false;
            GameObject.Find("Player").GetComponent<PlayerHealth>().SetGodModeHealthToNormal();
            GameObject.Find("Player").GetComponent<SpriteRenderer>().color = Color.white;
        }
        
    }




}
