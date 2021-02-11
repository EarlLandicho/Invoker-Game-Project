using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ComboBarUI : MonoBehaviour
{
    private TextMeshProUGUI comboBarText;

    void Awake()
    {
        comboBarText = GetComponent<TextMeshProUGUI>();
    }

    void LateUpdate()
    {
        comboBarText.text = ComboBar.currentBarLevel.ToString();
    }

}
