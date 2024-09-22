using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeerMinigame : MonoBehaviour
{
    [SerializeField] private GameObject _targetPrefab;

    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _miniGame;




    private int _targetsHit;
    private float _timeForTarget;

    private GameObject _currentTarget;

    private EndingSystem ES;
    [SerializeField] private PlayerControl PC;

    private void Start()
    {
        ES = GameObject.Find("Endings").GetComponent<EndingSystem>();
    }

    private void OnEnable()
    {
        SpawnTarget();
    }
    public void TargetHit()
    {
        _targetsHit++;

        if (_targetsHit >= 20)
        {
            Cursor.visible = true;
            _targetsHit = 0;
            PC._pauseLock = false;
            _miniGame.SetActive(false);
            ES.ActivateEnding(13);
            return;
        }

        SpawnTarget();

    }
    //ass
    public void SpawnTarget()
    {
        Destroy(_currentTarget);

        Vector3 _randomPosition = new Vector3(Random.Range(100f,700f),
            Random.Range(50f,300f));
        GameObject _spawnedObject = Instantiate(_targetPrefab, _randomPosition,
            Quaternion.identity);

        RectTransform RT = _spawnedObject.GetComponent<RectTransform>();

        _spawnedObject.transform.SetParent(transform,true);
        _spawnedObject.transform.localScale *= Random.Range(0.3f, 1.5f);
        RT.anchoredPosition = new Vector2(Random.Range(-1200, 1200),
            Random.Range(-600, 600));
        _spawnedObject.GetComponent<DeerBehaviour>().DM = this.GetComponent<DeerMinigame>();
        _spawnedObject.GetComponent<Button>().onClick.AddListener(delegate { TargetHit(); });

        Image _objectImage = _spawnedObject.GetComponent<Image>();
        Color _color = new Color(_objectImage.color.r, _objectImage.color.g,
            _objectImage.color.b, _objectImage.color.a * Random.Range(0.2f, 1f));
        _objectImage.color = _color;
        _currentTarget = _spawnedObject;
    }


    public void Lost()
    {
        Cursor.visible = true;
        _targetsHit = 0;
        print("lost");
        PC._pauseLock = false;
        _pauseMenu.SetActive(true);
        _miniGame.SetActive(false);
    }

}
