using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AdvancedSettingsCode : MonoBehaviour
{
    ////////////////////////////////////////////////////////////
    [Header("Lock")]
    public TMP_InputField _codeInput;
    public GameObject _lockScreen;
    public GameObject _menuContent;
    public GameObject _correctText;
    [SerializeField] private GameObject _backButton;
    ////////////////////////////////////////////////////////////
    [Header("SerialNumber")]
    [SerializeField] private TMP_Text _serialNumberText;
    private int _serialNumber;
    ////////////////////////////////////////////////////////////
    [Header("Login")]
    public bool _firstTimePress = false;
    public GameObject _popupAble;
    [SerializeField] private TMP_Text _reminderText;
    [SerializeField] private TMP_InputField _loginInput;
    [SerializeField] private TMP_InputField _passwordInput;
    ////////////////////////////////////////////////////////////
    [Header("Arrows")]
    [SerializeField] private GameObject _miniGame;
    [SerializeField] private GameObject _advancedSettingsMenu;
    private int _arrowCode;
    public void InputChanged()
    {
        if(_codeInput.text == "123")
        {
            _correctText.SetActive(true);
            _codeInput.interactable = false;
            _backButton.SetActive(false);
            Invoke("CorrectCode", 2f);
        }
    }
    public void CorrectCode()
    {
        _backButton.SetActive(true);
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

    public void ResetClick()
    {
        if (!_firstTimePress)
        {
            _popupAble.SetActive(true);
            _firstTimePress = true;
        }
        else
        {
            if(_loginInput.text == "crazy" && _passwordInput.text == "1234")
            {
                print("win");
            }
            else
            {
                _loginInput.text = "";
                _passwordInput.text = "";
                _reminderText.text = "Wrong password";
            }
        }
    }

    public void ArrowClick(int _whichButton)
    {
        switch (_whichButton)
        {
            case 1://Left
                _arrowCode = int.Parse(_arrowCode.ToString() + "1");
                break;
            case 2://Up
                _arrowCode = int.Parse(_arrowCode.ToString() + "2");
                break;
            case 3://Down
                _arrowCode = int.Parse(_arrowCode.ToString() + "3");
                break;
            case 4://Right
                _arrowCode = int.Parse(_arrowCode.ToString() + "4");
                break;
        }

        if(_arrowCode.ToString().Length > 6)
        {
            _arrowCode = int.Parse(_arrowCode.ToString().Remove(0, 1));
        }
        if(_arrowCode == 111222)
        {
            _miniGame.SetActive(true);
            _advancedSettingsMenu.SetActive(false);
        }
        print(_arrowCode);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ArrowClick(1);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ArrowClick(2);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ArrowClick(3);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ArrowClick(4);
        }
    }
}
