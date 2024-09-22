using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TutorialButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject _tutorialPopup;
    [SerializeField] private Image _image;

    [SerializeField] private Color _normalColor;
    [SerializeField] private Color _hoveredColor;

    public void OnPointerEnter(PointerEventData eventData)
    {
        _image.color = _hoveredColor;
        _tutorialPopup.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        _image.color = _normalColor;
        _tutorialPopup.SetActive(false);
    }
}
