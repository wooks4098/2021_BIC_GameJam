using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollBar : MonoBehaviour
{
    public Slider slider;
    public ScrollRect scrollRect;
    // Use this for initialization

    public void ChangeScrollPos()
    {
        scrollRect.verticalNormalizedPosition = slider.value;
    }
}
