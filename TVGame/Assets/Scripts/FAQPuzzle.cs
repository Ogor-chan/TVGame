using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FAQPuzzle : MonoBehaviour
{

    [SerializeField] private GameObject _helpMenu;
    [SerializeField] private GameObject _miniGameWindow;

    [SerializeField] private List<GameObject> _slides;

    private int _currentSlide = 0;
    private int _points;

    private EndingSystem ES;

    private void Start()
    {
        ES = GameObject.Find("Endings").GetComponent<EndingSystem>();
    }
    public void FAQButtonClick()
    {
        _miniGameWindow.SetActive(true);
        _helpMenu.SetActive(false);
        _slides[0].SetActive(true);
    }

    public void QuizButtonClick(int _whichButton)
    {
        switch (_currentSlide)
        {
            case 0:
                if(_whichButton == 3)
                {
                    _points++;
                }
                break;
            case 1:
                if (_whichButton == 3)
                {
                    _points++;
                }
                break;
            case 2:
                if (_whichButton == 2)
                {
                    _points++;
                }
                break;
            case 3:
                if (_whichButton == 3)
                {
                    _points++;
                }
                break;
            case 4:
                if (_whichButton == 1)
                {
                    _points++;
                }
                break;
            case 5:
                if (_whichButton == 0)
                {
                    _points++;
                }
                break;
            case 6:
                if (_whichButton == 1)
                {
                    _points++;
                }
                break;
        }

        NextSlide();

    }

    public void NextSlide()
    {
        print(_points);
        _slides[_currentSlide].SetActive(false);
        _currentSlide++;
        if(_currentSlide == 7)
        {
            if(_points == 7)
            {
                _points = 0;
                _currentSlide = 0;
                _miniGameWindow.SetActive(false);
                ES.ActivateEnding(8);
            }
            else
            {
                _points = 0;
                _currentSlide = 0;
                _miniGameWindow.SetActive(false);
                _helpMenu.SetActive(true);
            }
        }
        else
        {
            _slides[_currentSlide].SetActive(true);
        }

    }

}
