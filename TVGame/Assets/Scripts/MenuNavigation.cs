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
    [SerializeField] private GameObject _deerGame;
    [SerializeField] private GameObject _animalMenu;

    private PlayerControl PC;
    private void Start()
    {
        PC = GameObject.Find("GameManager").GetComponent<PlayerControl>();
    }
    public void settingsMenuClick()
    {
        PC._pauseLock = true;
        _pauseMenuObject.SetActive(false);
        _settingsMenuObject.SetActive(true);
    }

    public void pauseMenuClick()
    {
        PC._pauseLock = false;
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
        AdvancedSettingsCode ASC = _advancedSettingsMenuObject.GetComponent<AdvancedSettingsCode>();
        ASC._firstTimePress = false;
        ASC._popupAble.SetActive(false);
        ASC._lockScreen.SetActive(true);
        ASC._menuContent.SetActive(false);
        ASC._correctText.SetActive(false);
        ASC._codeInput.text = "";
        ASC._codeInput.interactable = true;
        _settingsMenuObject.SetActive(true);
        _advancedSettingsMenuObject.SetActive(false);
    }

    public void deerMinigameClick()
    {
        PC._pauseLock = true;
        _deerGame.SetActive(true);
        _pauseMenuObject.SetActive(false);
    }

    public void AnimalMenuClick()
    {
        PC._pauseLock = true;
        _animalMenu.SetActive(true);
        _pauseMenuObject.SetActive(false);
    }

    public void BackFromAnimalMenuClick()
    {
        PC._pauseLock = false;
        _animalMenu.SetActive(false);
        _pauseMenuObject.SetActive(true);
    }
}
