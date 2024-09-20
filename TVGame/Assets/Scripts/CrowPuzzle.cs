using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrowPuzzle : MonoBehaviour
{
    private int _timesPressed = 0;
    [SerializeField] private List<Vector3> _crowLocations;
    private Image _myImage;
    private Color _myColor;
    private void Start()
    {
        _myImage = GetComponent<Image>();
        _myColor = _myImage.color;
    }
    public void CrowPressed()
    {
        _myImage.color = new Color(_myColor.r, _myColor.g,
            _myColor.b, _myColor.a /2);
        _myColor = _myImage.color;
        _timesPressed++;
        if(_timesPressed >= 7)
        {
            print("Win");
            return;
        }
        transform.position = _crowLocations[_timesPressed];
    }
}
