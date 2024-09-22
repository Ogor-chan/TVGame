using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    public RectTransform crosshair;
    public Canvas canvas;


    private void OnEnable()
    {
        Cursor.visible = false;
    }
    //asss
    void Update()
    {
        Vector2 mousePosition = Input.mousePosition;

        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            mousePosition,
            canvas.worldCamera,
            out localPoint
        );

        Vector2 adjustedPosition = localPoint / crosshair.parent.localScale;

        crosshair.anchoredPosition = adjustedPosition;
    }
}
