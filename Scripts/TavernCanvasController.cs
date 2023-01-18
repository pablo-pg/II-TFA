using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TavernCanvasController : MonoBehaviour
{
    public Image imageSelector;

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
}
