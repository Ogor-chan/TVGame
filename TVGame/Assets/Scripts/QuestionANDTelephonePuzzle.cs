using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestionANDTelephonePuzzle : MonoBehaviour
{
    [SerializeField] private TMP_InputField _questionInput;
    [SerializeField] private GameObject _responseText;
    private bool Lock;

    private string _number;
    [SerializeField] private TMP_Text _numberDisplay;
    private bool NumberLock;
    public void ConfirmButton()
    {
        if (Lock)
        {
            return;
        }
        if(_questionInput.text == "What is a god?"||
            _questionInput.text == "what is a god?")
        {
            print("win");
        }
        else
        {
            StartCoroutine(DisplayText());
            _questionInput.text = "";
        }
    }
    IEnumerator DisplayText()
    {
        Lock = true;
        _responseText.SetActive(true);
        yield return new WaitForSecondsRealtime(2);
        _responseText.SetActive(false);
        Lock = false;
    }


    public void NumberButtonClick(int _whichNumber)
    {
        if (NumberLock)
        {
            return;
        }
        _number = _number + _whichNumber;
        _numberDisplay.text = _number;
        if(_number.Length == 6)
        {
            if(_number == "126667")
            {
                print("win");
            }
            else
            {
                StartCoroutine(DeleteDisplay());
            }
        }
    }

    IEnumerator DeleteDisplay()
    {
        NumberLock = true;
        yield return new WaitForSecondsRealtime(2);
        _numberDisplay.text = "";
        _number = "";
        NumberLock = false;
    }






}
