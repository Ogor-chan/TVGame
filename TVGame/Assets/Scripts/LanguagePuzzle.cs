using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LanguagePuzzle : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Dropdown _dropDown1;
    [SerializeField] private TMPro.TMP_Dropdown _dropDown2;
    [SerializeField] private TMPro.TMP_Dropdown _dropDown3;
    [SerializeField] private TMP_Dropdown _dropdown4;

    public void Check()
    {
        if (_dropDown1.value == 1 &&
            _dropDown2.value == 6 &&
            _dropDown3.value == 4 &&
            _dropdown4.value == 3)
        {
            print("WIN");
        }
    }
}
