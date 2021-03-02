using UnityEngine;
using UnityEngine.UI;

public class ComboBarUI : MonoBehaviour
{
    [SerializeField] private Sprite stage1ComboBar;
    [SerializeField] private Sprite stage2ComboBar;
    [SerializeField] private Sprite stage3ComboBar;
    [SerializeField] private Sprite stage4ComboBar;
    private Slider slider;
    private ComboBar comboBar;
    private Image comboBarImage;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        comboBar = FindObjectOfType<ComboBar>();
        comboBarImage = transform.Find("Border").GetComponent<Image>();
    }

    private void LateUpdate()
    {
        slider.value = comboBar.GetComboBarLevel();

        switch (comboBar.GetComboBarStage())
        {
            case 1:
                comboBarImage.sprite = stage1ComboBar;
                break;

            case 2:
                comboBarImage.sprite = stage2ComboBar;
                break;

            case 3:
                comboBarImage.sprite = stage3ComboBar;
                break;

            case 4:
                comboBarImage.sprite = stage4ComboBar;
                break;
        }
    }
}