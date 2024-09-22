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

    [SerializeField] private EndingSystem ES;

    public bool _pauseLock = false;

    private bool _paused;

    private int _timesPaused;
    private float _clipPlayedFor;

    private void Start()
    {
        ES = GameObject.Find("Endings").GetComponent<EndingSystem>();
    }

    void Update()
    {
        if (!_paused)
        {
            _clipPlayedFor += Time.deltaTime;
        }

        if(_clipPlayedFor >= 20f)
        {
            _timesPaused = 0;
            _clipPlayedFor = 0;
            _pauseMenu.SetActive(false);
            _pauseLock = true;
            ES.ActivateEnding(12);
        }

        if(_timesPaused >= 10)
        {
            _timesPaused = 0;
            _clipPlayedFor = 0;
            _pauseMenu.SetActive(false);
            _pauseLock = true;
            ES.ActivateEnding(1);
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
                PauseVideo();
                _paused = true;
                _timesPaused++;
                print(_timesPaused);
            }
            else
            {
                PlayVideo();
                _paused = false;
            }
            _pauseMenu.SetActive(!_pauseMenu.activeInHierarchy);
        }

    }



    public void PlayVideo()
    {
        _videoPlayer.Play();
    }

    public void PauseVideo()
    {
        _videoPlayer.Pause();
    }

    public void ReplayVideo()
    {
        _videoPlayer.frame = 0;
        _videoPlayer.Play();
    }
}
