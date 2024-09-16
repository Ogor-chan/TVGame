using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{


    [SerializeField] private GameObject _pauseMenu;

    private bool _pauseLock = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_pauseLock)
        {
            _pauseMenu.SetActive(!_pauseMenu.activeInHierarchy);
            _pauseLock = true;
        }
    }
}
