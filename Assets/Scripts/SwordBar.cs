using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwordBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void setMaxDurability(int swordDurability)
    {
        slider.maxValue = swordDurability;
        slider.value = swordDurability;
        fill.color = gradient.Evaluate(1f);
    }

    public void setDurability(int swordDurability)
    {
        slider.value = swordDurability;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
