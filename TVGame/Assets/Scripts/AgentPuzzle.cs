using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AgentPuzzle : MonoBehaviour
{
    [SerializeField] private GameObject _miniGameWindow;
    [SerializeField] private GameObject _helpMenu;
    [SerializeField] private List<GameObject> _slides;
    [SerializeField] private Slider _timerSlider;

    private float _timerSpeed = 0.25f;
    private void Update()
    {
        _timerSlider.value -= _timerSpeed * Time.deltaTime;
        if(_timerSlider.value <= 0)
        {
            Lost();
        }
    }

    private int _currentSlide = 0;
    public void AgentButtonClick()
    {
        _timerSlider.value = 1;
        _miniGameWindow.SetActive(true);
        _helpMenu.SetActive(false);
        _slides[0].SetActive(true);
    }

    public void AnswerButton(bool _answer)
    {
        switch (_currentSlide)
        {
            case 0:
                if (!_answer)
                {
                    NextSlide();
                }
                else
                {
                    Lost();
                }
                break;
            case 1:
                if (_answer)
                {
                    NextSlide();
                }
                else
                {
                    Lost();
                }
                break;
            case 2:
                if (_answer)
                {
                    NextSlide();
                }
                else
                {
                    Lost();
                }
                break;
            case 3:
                if (!_answer)
                {
                    NextSlide();
                }
                else
                {
                    Lost();
                }
                break;
            case 4:
                if (!_answer)
                {
                    NextSlide();
                }
                else
                {
                    Lost();
                }
                break;
            case 5:
                if (_answer)
                {
                    NextSlide();
                }
                else
                {
                    Lost();
                }
                break;
            case 6:
                if (_answer)
                {
                    NextSlide();
                }
                else
                {
                    Lost();
                }
                break;
            case 7:
                if (!_answer)
                {
                    NextSlide();
                }
                else
                {
                    Lost();
                }
                break;
            case 8:
                if (_answer)
                {
                    NextSlide();
                }
                else
                {
                    Lost();
                }
                break;
            case 9:
                if (!_answer)
                {
                    NextSlide();
                }
                else
                {
                    Lost();
                }
                break;
        }
    }

    public void Lost()
    {
        _slides[_currentSlide].SetActive(false);
        _currentSlide = 0;
        _helpMenu.SetActive(true);
        _miniGameWindow.SetActive(false);
    }
    public void NextSlide()
    {
        _timerSlider.value = 1;
        if(_currentSlide == 9)
        {
            print("win");
            return;
        }
        _slides[_currentSlide].SetActive(false);
        _currentSlide++;
        _slides[_currentSlide].SetActive(true);
    }


}
