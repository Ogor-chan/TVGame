using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuNavigation : MonoBehaviour
{
    /// <summary>
    /// ASS
    /// </summary>
    [SerializeField] private GameObject _pauseMenuObject;
    [SerializeField] private GameObject _settingsMenuObject;

    public void settingsMenuClick()
    {
        _pauseMenuObject.SetActive(false);
        _settingsMenuObject.SetActive(true);
    }

    public void pauseMenuClick()
    {
        _pauseMenuObject.SetActive(true);
        _settingsMenuObject.SetActive(false);
    }

}
