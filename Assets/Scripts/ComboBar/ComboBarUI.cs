using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class ComboBarUI : MonoBehaviour
{
    private TextMeshProUGUI comboBarText;
    private Slider slider;

    void Awake()
    {
        slider = GetComponent<Slider>();
        comboBarText = GetComponent<TextMeshProUGUI>();
    }

    void LateUpdate()
    {
        comboBarText.text = ComboBar.currentBarLevel.ToString();
        slider.value = ComboBar.currentBarLevel;
    }

}
