using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Door : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private Sprite _normalSprite;
    [SerializeField] private Sprite _hoverSprite;
    [SerializeField] private Image _image;

    public void OnPointerEnter(PointerEventData eventData)
    {
        _image.sprite = _hoverSprite;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        _image.sprite = _normalSprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        print("Quit");
        Application.Quit();
    }

}
