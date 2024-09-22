using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AnimalsPuzzle : MonoBehaviour
{
    private int _rightAnimals;
    private int _wrongAnimals;

    private EndingSystem ES;
    [SerializeField] private GameObject _animalMenu;
    [SerializeField] private Toggle[] _toggles;

    private void Start()
    {
        ES = GameObject.Find("Endings").GetComponent<EndingSystem>();
    }

    public void _toggleClicked(bool _rightToggle)
    {
        Toggle _clickedToggle =
            EventSystem.current.currentSelectedGameObject.GetComponent<Toggle>();

        if(_clickedToggle.isOn)
        {
            if (_rightToggle)
            {
                _rightAnimals++;
            }
            else
            {
                _wrongAnimals++;
            }
        }
        else
        {
            if (_rightToggle)
            {
                _rightAnimals--;
            }
            else
            {
                _wrongAnimals--;
            }
        }

        print(_rightAnimals);
        if(_rightAnimals == 4 && _wrongAnimals == 0)
        {
            foreach (Toggle item in _toggles)
            {
                item.isOn = false;
            }

            _rightAnimals = 0;
            _wrongAnimals = 0;
            _animalMenu.SetActive(false);
            ES.ActivateEnding(6);
        }
    }


}
