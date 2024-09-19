using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowButtonAnim : MonoBehaviour
{
    [SerializeField] private Color _initColor;
    [SerializeField] private Color _clickColor;
    [SerializeField] private Image _buttonImage;

    [SerializeField] private KeyCode _buttonArrow;

    private void Start()
    {
        _buttonImage.color = _initColor;
    }
    private void Update()
    {
        if (Input.GetKeyDown(_buttonArrow))
        {
            _buttonImage.color = _clickColor;
        }
        if (Input.GetKeyUp(_buttonArrow))
        {
            _buttonImage.color = _initColor;
        }
    }


}
