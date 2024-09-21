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

    public RectTransform uiElement;
    public Vector3 targetPosition;
    public float moveSpeed = 2.0f;

    private bool isMoving = false;

    [SerializeField] private Animator _animator;
    private void Start()
    {
        _myImage = GetComponent<Image>();
        _myColor = _myImage.color;
    }
    public void CrowPressed()
    {
        _myImage.color = new Color(_myColor.r, _myColor.g,
            _myColor.b, _myColor.a /1.3f);
        _myColor = _myImage.color;
        _timesPressed++;
        if(_timesPressed >= 7)
        {
            print("Win");
            return;
        }
        targetPosition = _crowLocations[_timesPressed];
        if(targetPosition.x < uiElement.anchoredPosition.x)
        {
            this.transform.localScale = new Vector3(4, 4, 4);
        }
        else if(targetPosition.x > uiElement.anchoredPosition.x)
        {
            this.transform.localScale = new Vector3(-4, 4, 4);

        }
        _animator.Play("Flight");
        isMoving = true;
    }

    void Update()
    {
        if (isMoving)
        {
            MoveTowardsTarget();
        }
    }

    private void MoveTowardsTarget()
    {
        uiElement.anchoredPosition = Vector3.MoveTowards(uiElement.anchoredPosition, targetPosition, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(uiElement.anchoredPosition, targetPosition) <= 5f)
        {
            _animator.Play("Idle");
            isMoving = false;

        }
    }
}
