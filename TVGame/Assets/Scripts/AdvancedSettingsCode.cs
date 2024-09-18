using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AdvancedSettingsCode : MonoBehaviour
{
    [SerializeField] private TMP_InputField _codeInput;
    [SerializeField] private GameObject _lockScreen;
    [SerializeField] private GameObject _menuContent;
    [SerializeField] private GameObject _correctText;

    [SerializeField] private TMP_Text _serialNumberText;
    private int _serialNumber;

    public void InputChanged()
    {
        if(_codeInput.text == "123")
        {
            _correctText.SetActive(true);
            _codeInput.interactable = false;
            Invoke("CorrectCode", 2f);
        }
    }
    public void CorrectCode()
    {
        _correctText.SetActive(false);
        _lockScreen.SetActive(false);
        _menuContent.SetActive(true);
    }

    public void SerialNumberButtons(int _whichButton)
    {
        switch (_whichButton)
        {
            case 1:
                _serialNumber += 7;
                break;
            case 2:
                _serialNumber -= 5;
                break;
            case 3:
                _serialNumber *= 3;
                break;
            case 4:
                _serialNumber /= 2;
                break;
        }

        if(_serialNumber> 9999)
        {
            _serialNumber = 9999;
        }
        if(_serialNumber < 0000)
        {
            _serialNumber = 0000;
        }

        _serialNumberText.text = _serialNumber.ToString("D4");

        if(_serialNumber == 3012)
        {
            print("win");
        }
    }


}
