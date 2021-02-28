using UnityEngine;
using UnityEngine.UI;

public class ComboBarUI : MonoBehaviour
{
    private Slider slider;
    private ComboBar comboBar;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        comboBar = FindObjectOfType<ComboBar>();
    }

    private void LateUpdate()
    {
        slider.value = comboBar.GetComboBarLevel();
    }
}