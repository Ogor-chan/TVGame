using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowButtonAnim : MonoBehaviour
{
    [SerializeField] private Sprite _initSprite;
    [SerializeField] private Sprite _clickSprite;
    [SerializeField] private Image _buttonImage;

    [SerializeField] private KeyCode _buttonArrow;

    private void Update()
    {
        if (Input.GetKeyDown(_buttonArrow))
        {
            _buttonImage.sprite = _clickSprite;
        }
        if (Input.GetKeyUp(_buttonArrow))
        {
            _buttonImage.sprite = _initSprite;
        }
    }


}
