using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NoteSpawning : MonoBehaviour
{
    ///Okay so this is gonna be totaly retarded but i dont care
    ///Its not optimal in the slightest, it may even be the most
    ///bat shit insane way to code this, but its way too late, i slept
    ///way too little and we do not have enought time to do it right
    ///So sorry in advance to however has to read this shit

    [SerializeField] private bool[] _leftNotes;
    [SerializeField] private bool[] _upNotes;
    [SerializeField] private bool[] _downNotes;
    [SerializeField] private bool[] _rightNotes;

    [SerializeField] private Vector3[] _spawnPositions;
    // 0 - Left, 1 - Up, 2 - Down, 3 - Right
    // TAK WIEM ¯E JU¯ POWINIENEM ZROBIÆ ENUMA 
    private float _noteInterval = 0.5f;
    [SerializeField] private GameObject[] _notePrefabs;
    private int _currentNote = 0;
    [SerializeField] private AudioSource AS;

    private int _erorrs;
    [SerializeField] private GameObject[] _errorObjects;
    private float _errorCooldown = 0.3f;
    private bool _erorrLock = false;


    [SerializeField] private GameObject _miniGame;
    [SerializeField] private GameObject _advancedSettingsMenu;

    [SerializeField] private Sprite _leftArrowSprite;
    [SerializeField] private Sprite _upArrowSprite;
    [SerializeField] private Sprite _downArrowSprite;
    [SerializeField] private Sprite _rightArrowSprite;

    private EndingSystem ES;

    private void Start()
    {
        ES = GameObject.Find("Endings").GetComponent<EndingSystem>();
    }

    IEnumerator PlayingNotes()
    {
        if (_leftNotes[_currentNote] == true)
        {
            GameObject spawnedNote = Instantiate(_notePrefabs[0],
                _spawnPositions[0], Quaternion.identity, transform);
        }
        if (_upNotes[_currentNote] == true)
        {
            GameObject spawnedNote = Instantiate(_notePrefabs[1],
                _spawnPositions[1], Quaternion.identity, transform);

        }
        if (_downNotes[_currentNote] == true)
        {
            GameObject spawnedNote = Instantiate(_notePrefabs[2],
                _spawnPositions[2], Quaternion.identity,transform);

        }
        if (_rightNotes[_currentNote] == true)
        {
            GameObject spawnedNote = Instantiate(_notePrefabs[3],
                _spawnPositions[3], Quaternion.identity, transform);

        }



        _currentNote++;
        if(_currentNote+1 >= _leftNotes.Length)
        {
            _erorrs = 0;
            _erorrLock = false;
            foreach (Transform child in this.transform)
            {
                Destroy(child.gameObject);
            }
            foreach (var item in _errorObjects)
            {
                item.SetActive(false);
            }

            _erorrs = 0;
            _erorrLock = false;
            foreach (Transform child in this.transform)
            {
                Destroy(child.gameObject);
            }
            foreach (var item in _errorObjects)
            {
                item.SetActive(false);
            }
            AS.Stop();
            _currentNote = 0;
            _miniGame.SetActive(false);
            ES.ActivateEnding(0);
        }
        yield return new WaitForSecondsRealtime(_noteInterval);
        StartCoroutine(PlayingNotes());
    }

    private void Delay()
    {
        StartCoroutine(PlayingNotes());
    }

    private void OnEnable()
    {
        Invoke("Delay", 2f);
        Invoke("MusicDelay", 3f);

    }

    private void MusicDelay()
    {
        AS.Play();
    }
    public void GotError()
    {
        if (!_erorrLock)
        {
            _erorrLock = true;
            _erorrs++;
            if(_erorrs == 6)
            {
                _erorrs = 0;
                _erorrLock = false;
                foreach (Transform child in this.transform)
                {
                    Destroy(child.gameObject);
                }
                foreach (var item in _errorObjects)
                {
                    item.SetActive(false);
                }
                _currentNote = 0;
                _advancedSettingsMenu.SetActive(true);
                _miniGame.SetActive(false);
                return;
            }
            _errorObjects[_erorrs - 1].SetActive(true);
            Invoke("UnlockError", _errorCooldown);
        }
    }

    public void UnlockError()
    {
        _erorrLock = false;
    }
}
