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
    [SerializeField] private GameObject _helpMenuObject;
    [SerializeField] private GameObject _advancedSettingsMenuObject;

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

    public void backFromHelpClick()
    {
        _settingsMenuObject.SetActive(true);
        _helpMenuObject.SetActive(false);
    }

    public void advancedSettingsMenuClick()
    {
        _advancedSettingsMenuObject.SetActive(true);
        _settingsMenuObject.SetActive(false);
    }

    public void backFromAdvancedSettingsClick()
    {
        _settingsMenuObject.SetActive(true);
        _advancedSettingsMenuObject.SetActive(false);
    }

}
