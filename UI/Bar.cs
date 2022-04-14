using UnityEngine.UI;
using TMPro;
using UnityEngine;

public abstract class Bar : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI txSliderValue;
    public void SetMaxValue(float health)
    {
        slider.maxValue = health;
        UpdateTextValue();
    }
    public void SetValue(float health)
    {
        slider.value = health;
        UpdateTextValue();
    }
    public void UpdateTextValue()
    {
        txSliderValue.text = $"{slider.value}/{slider.maxValue}";
    }
}
