using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    public RectTransform crosshair;
    public Canvas canvas;

    private void Start()
    {
        Cursor.visible = false;
    }

    //asss
    void Update()
    {
        Vector2 cursorPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform,
            Input.mousePosition, canvas.worldCamera, out cursorPosition);

        crosshair.anchoredPosition = cursorPosition;
    }
}
