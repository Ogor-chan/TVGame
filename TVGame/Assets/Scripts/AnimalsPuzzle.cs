using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AnimalsPuzzle : MonoBehaviour
{
    private int _rightAnimals;
    private int _wrongAnimals;

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
        if(_rightAnimals == 6 && _wrongAnimals == 0)
        {
            print("Win");
        }
    }


}
