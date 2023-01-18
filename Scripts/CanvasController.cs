using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public Image imageSelector;
    public Slider sliderBar;

    public void changePickableBallColor(bool isSelect) {
        if (isSelect) {
            imageSelector.color = Color.green;
        } else {
            imageSelector.color = Color.white;
        }
    }

    public void hideCursor(bool hide) {
        imageSelector.enabled = !hide;
    }

    public void EnableSlider(bool enable) {
        sliderBar.gameObject.SetActive(enable);
    }

    public void SetValueBar(float value) {
        sliderBar.value = value;
    }
}
