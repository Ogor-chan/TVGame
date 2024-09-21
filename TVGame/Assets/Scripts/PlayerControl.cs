using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Video;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _camera;
    [SerializeField] private Animator _animCamera;

    [SerializeField] private GameObject _deerButton;
    [SerializeField] private GameObject _crowButton;

    [SerializeField] private VideoPlayer _videoPlayer;

    public bool _pauseLock = false;

    private bool _paused;

    private int _timesPaused;
    private float _clipPlayedFor;

    void Update()
    {
        if (!_paused)
        {
            _clipPlayedFor += Time.deltaTime;
        }

        if(_clipPlayedFor >= 20f)
        {
            print("win");
        }

        if(_timesPaused >= 20)
        {
            print("WIN");
        }
        ///CrowButton
        if(_clipPlayedFor >= 10f && _clipPlayedFor <= 10.5f)
        {
            _crowButton.SetActive(true);
        }
        if(_clipPlayedFor >= 13f && _clipPlayedFor <= 13.5f)
        {
            _crowButton.SetActive(false);
        }
        ///DeerButton
        if (_clipPlayedFor >= 5f && _clipPlayedFor <= 5.5f)
        {
            _deerButton.SetActive(true);
        }
        if (_clipPlayedFor >= 8f && _clipPlayedFor <= 8.5f)
        {
            _deerButton.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !_pauseLock)
        {
            if (!_pauseMenu.activeInHierarchy)
            {
                _videoPlayer.Pause();
                _paused = true;
                _timesPaused++;
                print(_timesPaused);
            }
            else
            {
                _videoPlayer.Play();
                _paused = false;
            }
            _pauseMenu.SetActive(!_pauseMenu.activeInHierarchy);
        }

    }
}
