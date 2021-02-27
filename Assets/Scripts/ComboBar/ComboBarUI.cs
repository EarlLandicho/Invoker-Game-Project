using UnityEngine;
using UnityEngine.UI;

public class ComboBarUI : MonoBehaviour
{
    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void LateUpdate()
    {
        slider.value = ComboBar.currentBarLevel;
    }
}