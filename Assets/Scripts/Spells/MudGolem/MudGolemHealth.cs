using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudGolemHealth : Health
{
    [SerializeField] private float comboBarAddedHealth = 20;
    private ComboBar comboBar;
    private float healthTemp;
    
    private new void Awake()
    {
        base.Awake();
        comboBar = GameObject.Find("GameManager").GetComponent<ComboBar>();
    }
    
    private void Start()
    {
        ComboBarCheck();
    }
    
    private void ComboBarCheck()
    {
        switch (comboBar.GetComboBarStage())
        {
            case 1:
                currentHealth = maxHealth;
                break;
            case 2:
                currentHealth = maxHealth + comboBarAddedHealth;
                break;
            case 3:
            case 4:
                currentHealth = maxHealth + 2 * comboBarAddedHealth;
                break;
            default:
                return;
        }
    }
}
