using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowButtonAnim : MonoBehaviour
{
    [SerializeField] private Color _initColor;
    [SerializeField] private Color _clickColor;
    [SerializeField] private Image _buttonImage;

    public bool _changeColor = false;
    private float _changeSpeed = 0.05f;
    private float _lerpTime = 0f;

    private void Start()
    {
        _buttonImage.color = _initColor;
    }
    private void Update()
    {
        if (_changeColor)
        {
            _lerpTime += _changeSpeed * Time.deltaTime;
            _lerpTime = Mathf.Clamp01(_lerpTime);
            _buttonImage.color = Color.Lerp(_initColor, _clickColor, _lerpTime);

            if (Mathf.Approximately(_lerpTime, 1f))
            {
                _changeColor = false;
            }
        }
        else
        {
            _lerpTime -= _changeSpeed * Time.deltaTime;
            _lerpTime = Mathf.Clamp01(_lerpTime);
            _buttonImage.color = Color.Lerp(_clickColor, _initColor, _lerpTime);
        }

    }


}
