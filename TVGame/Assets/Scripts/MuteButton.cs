using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private Sprite _normalSprite;
    [SerializeField] private Sprite _clickedSprite;
    [SerializeField] private Image _image;

    private bool _clicked = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.transform.localScale *= 1.2f;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        this.transform.localScale /= 1.2f;
    }
//assss
    public void OnPointerClick(PointerEventData eventData)
    {
        _clicked = !_clicked;

        if (_clicked)
        {
            AudioListener.volume = 0;
            _image.sprite = _clickedSprite;
        }
        else
        {
            AudioListener.volume = 1;
            _image.sprite = _normalSprite;

        }
    }
}
