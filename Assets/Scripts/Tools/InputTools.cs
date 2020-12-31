using System;
using UnityEngine;
using UnityEngine.SceneManagement;

//Debugging Tools
public class InputTools : MonoBehaviour
{
    public event Action InstructionButtonPressed = delegate { };

    public event Action GodModeActivated = delegate { };

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            //Reload current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            //Load next scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            //Load first scene
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //Open instructions
            InstructionButtonPressed();
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            //Quit G
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            //GodMode
            GodModeActivated();
        }
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            GameObject.Find("Player").GetComponent<PlayerHealth>().TakeDamage(20);
        }
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            GameObject.Find("Player").GetComponent<PlayerHealth>().TakeHealing(30);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            GameObject.Find("Player").GetComponent<StatusEffect>().BecomePoisoned();
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            GameObject.Find("Player").GetComponent<StatusEffect>().BecomeBurned();
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            GameObject.Find("Player").GetComponent<StatusEffect>().BecomeOiled();
        }
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            GameObject.Find("Player").GetComponent<StatusEffect>().Dispel(); ;
        }
    }
}