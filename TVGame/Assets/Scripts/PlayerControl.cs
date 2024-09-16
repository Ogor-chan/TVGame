using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _camera;
    [SerializeField] private Animator _animCamera;

    private bool _pauseLock = false;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_pauseLock)
        {
            _pauseMenu.SetActive(!_pauseMenu.activeInHierarchy);
            _pauseLock = true;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Ending();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            _animCamera.Play("CameraZoomIn");
        }

    }

    public void Ending()
    {
        _animCamera.Play("CameraZoomOut");
    }
}
