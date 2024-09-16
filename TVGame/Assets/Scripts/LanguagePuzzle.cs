using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LanguagePuzzle : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Dropdown _dropDown1;
    [SerializeField] private TMPro.TMP_Dropdown _dropDown2;
    [SerializeField] private TMPro.TMP_Dropdown _dropDown3;

    public void Check()
    {
        if (_dropDown1.value == 1 &&
            _dropDown2.value == 6 &&
            _dropDown3.value == 4)
        {
            print("WIN");
        }
    }
}
