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
    [SerializeField] private GameObject _settingsMenu;

    private EndingSystem ES;
    private void Start()
    {
        ES = GameObject.Find("Endings").GetComponent<EndingSystem>();
    }
    public void Check()
    {
        if (_dropDown1.value == 5 &&
            _dropDown2.value == 7 &&
            _dropDown3.value == 6 &&
            _dropdown4.value == 11)
        {
            _dropdown4.value = 0;
            _dropDown1.value = 0;
            _dropDown2.value = 0;
            _dropDown3.value = 0;

            _settingsMenu.SetActive(false);
            ES.ActivateEnding(2);
        }
    }
}
