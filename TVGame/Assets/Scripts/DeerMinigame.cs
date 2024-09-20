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

    private void OnEnable()
    {
        SpawnTarget();
    }
    public void TargetHit()
    {
        _targetsHit++;

        if (_targetsHit >= 20)
        {
            print("win");
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

        _spawnedObject.transform.SetParent(transform,true);
        _spawnedObject.transform.localScale *= Random.Range(0.3f, 1.5f);
        _spawnedObject.GetComponent<DeerBehaviour>().DM = this.GetComponent<DeerMinigame>();
        _spawnedObject.GetComponent<Button>().onClick.AddListener(delegate { SpawnTarget(); });

        Image _objectImage = _spawnedObject.GetComponent<Image>();
        Color _color = new Color(_objectImage.color.r, _objectImage.color.g,
            _objectImage.color.b, _objectImage.color.a * Random.Range(0.2f, 1f));
        _objectImage.color = _color;
        _currentTarget = _spawnedObject;
    }


    public void Lost()
    {
        _targetsHit = 0;
        print("lost");
        _pauseMenu.SetActive(true);
        _miniGame.SetActive(false);
    }

}
