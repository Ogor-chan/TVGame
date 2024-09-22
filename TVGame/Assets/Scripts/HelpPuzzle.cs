using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HelpPuzzle : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private GameObject _inputFieldObject;

    [SerializeField] private GameObject _settingsMenu;
    [SerializeField] private GameObject _helpMenu;

    private bool _firstClick = false;

    public void HelpButtonClick()
    {
        if (!_firstClick)
        {
            _firstClick = true;
            _inputFieldObject.SetActive(true);
        }
        else
        {
            if(_inputField.text == "frost101")
            {
                _helpMenu.SetActive(true);
                _inputField.text = "";
                _firstClick = false;
                _inputFieldObject.SetActive(false);
                _settingsMenu.SetActive(false);
            }
        }
    }


}
