using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlidersPuzzle : MonoBehaviour
{

    [SerializeField] private Slider _slider1;
    [SerializeField] private Slider _slider2;
    [SerializeField] private Slider _slider3;
    [SerializeField] private Slider _slider4;

    private float _lastSliderValue1;
    private float _lastSliderValue2;
    private float _lastSliderValue3;
    private float _lastSliderValue4;

    [SerializeField] private GameObject _settingsMenu;

    private EndingSystem ES;


    private void Start()
    {
        ES = GameObject.Find("Endings").GetComponent<EndingSystem>();
    }

    private void OnEnable()
    {
        _lastSliderValue1 = _slider1.value;
        _lastSliderValue2 = _slider2.value;
        _lastSliderValue3 = _slider3.value;
        _lastSliderValue4 = _slider4.value;
    }
    /// <summary>
    /// Pierwszy slider porusza pierwszymi dwoma
    /// Drugi slider porusza wszystkimi oprócz pierwszego
    /// Trrzeci slider porusza ostatnimi dwoma
    /// Czwarty slider porusza pierwszym i ostatnim
    /// </summary>

    public void FirstSliderMoved()
    {
        if (EventSystem.current.currentSelectedGameObject == _slider1.gameObject)
        {
            float value = _lastSliderValue1 - _slider1.value;
            _slider2.value -= value;
            _lastSliderValue1 = _slider1.value;
            _lastSliderValue2 = _slider2.value;
        }
        Check();
    }

    public void SecondSliderMoved()
    {
        if (EventSystem.current.currentSelectedGameObject == _slider2.gameObject)
        {
            float value = _lastSliderValue2 - _slider2.value;
            _slider3.value -= value;
            _slider4.value -= value;
            _lastSliderValue2 = _slider2.value;
            _lastSliderValue3 = _slider3.value;
            _lastSliderValue4 = _slider4.value;
        }
        Check();
    }
    public void ThirdSliderMoved()
    {
        if (EventSystem.current.currentSelectedGameObject == _slider3.gameObject)
        {
            float value = _lastSliderValue3 - _slider3.value;
            _slider4.value -= value;
            _lastSliderValue3 = _slider3.value;
            _lastSliderValue4 = _slider4.value;
        }
        Check();
    }
    public void FourthSliderMoved()
    {
        if (EventSystem.current.currentSelectedGameObject == _slider4.gameObject)
        {
            float value = _lastSliderValue4 - _slider4.value;
            _slider1.value -= value;
            _lastSliderValue1 = _slider1.value;
            _lastSliderValue4 = _slider4.value;
        }
        Check();
    }

    public void Check()
    {
        if(_slider1.value>= 0.6f && _slider1.value<= 0.7f)
        {
            if(_slider2.value>= 0.2f && _slider2.value<= 0.3f)
            {
                if(_slider3.value>= 0.8f && _slider3.value<= 0.9f)
                {
                    if(_slider4.value>= 0.4f && _slider4.value<= 0.5f)
                    {
                        _slider1.value = 0;
                        _slider2.value = 0;
                        _slider3.value = 0;
                        _slider4.value = 0;
                        _lastSliderValue1 = 0;
                        _lastSliderValue1 = 0;
                        _lastSliderValue1 = 0;
                        _lastSliderValue1 = 0;

                        _settingsMenu.SetActive(false);
                        ES.ActivateEnding(11);
                    }
                }
            }
        }
    }
}
