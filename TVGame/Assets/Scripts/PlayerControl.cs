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
    [SerializeField] private MenuNavigation MN;

    public AudioSource MyASS;

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

        if(_clipPlayedFor >= 122f)
        {
            _timesPaused = 0;
            _clipPlayedFor = 0;
            _pauseMenu.SetActive(false);
            _pauseLock = true;
            ES.ActivateEnding(12);
        }

        if(_timesPaused >= 20)
        {
            _timesPaused = 0;
            _clipPlayedFor = 0;
            _pauseMenu.SetActive(false);
            _pauseLock = true;
            ES.ActivateEnding(1);
        }
        ///CrowButton
        if(_clipPlayedFor >= 16f && _clipPlayedFor <= 16.5f)
        {
            _crowButton.SetActive(true);
        }
        if(_clipPlayedFor >= 31f && _clipPlayedFor <= 31.5f)
        {
            _crowButton.SetActive(false);
        }
        ///DeerButton
        if (_clipPlayedFor >= 88f && _clipPlayedFor <= 88.5f)
        {
            _deerButton.SetActive(true);
        }
        if (_clipPlayedFor >= 93f && _clipPlayedFor <= 93.5f)
        {
            _deerButton.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !_pauseLock)
        {
            if (!_pauseMenu.activeInHierarchy)
            {
                MyASS.Pause();
                MN.ASss.UnPause();
                PauseVideo();
                _paused = true;
                _timesPaused++;
                print(_timesPaused);
            }
            else
            {
                MyASS.UnPause();
                MN.ASss.Pause();
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
