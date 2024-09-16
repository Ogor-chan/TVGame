using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FAQPuzzle : MonoBehaviour
{

    [SerializeField] private GameObject _helpMenu;
    [SerializeField] private GameObject _miniGameWindow;

    private int _currentSlide = 0;
    private int _points;

    public void FAQButtonClick()
    {
        _miniGameWindow.SetActive(true);
        _helpMenu.SetActive(false);
    }

    public void QuizButtonClick(int _whichButton)
    {
        if(_currentSlide == 0 && _whichButton == 0)
        {
            _points++;
        }




    }

    public void NextSlide()
    {

    }

}
