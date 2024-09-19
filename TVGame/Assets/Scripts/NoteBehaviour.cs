using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBehaviour : MonoBehaviour
{
    private float _fallingSpeed = 200f;
    public int _whichButton;
    [SerializeField] private RectTransform _myTransform;
    private NoteSpawning NS;
    private void Start()
    {
        NS = GameObject.Find("NoteSpawner").GetComponent<NoteSpawning>();
    }

    // 0 - Left
    // 1 - Up
    // 2 - Down
    // 3 - Right

    void Update()
    {
        ///Ye ye a tone of if statements inside an update function in a 
        ///frequently spawning prefab, not my proudest work
        _myTransform.position = new Vector3(_myTransform.position.x,
            _myTransform.position.y - _fallingSpeed * Time.deltaTime,
            _myTransform.position.z);
        if(_whichButton == 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if(_myTransform.position.y < 80f && _myTransform.position.y > -20)
                {
                    Destroy(this.gameObject);
                }
                else if (_myTransform.position.y < 200f)
                {
                    print("Wrong timing");
                    NS.GotError();
                }
            }
        }
        else if (_whichButton == 1)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (_myTransform.position.y < 80f && _myTransform.position.y > -20)
                {
                    Destroy(this.gameObject);
                }
                else if (_myTransform.position.y < 200f)
                {
                    print("Wrong timing");
                    NS.GotError();
                }
            }
        }
        else if (_whichButton == 2)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (_myTransform.position.y < 80f && _myTransform.position.y > -20)
                {
                    Destroy(this.gameObject);
                }
                else if (_myTransform.position.y < 200f)
                {
                    print("Wrong timing");
                    NS.GotError();
                }
            }
        }
        else if (_whichButton == 3)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (_myTransform.position.y < 80f && _myTransform.position.y > -20)
                {
                    Destroy(this.gameObject);
                }
                else if (_myTransform.position.y < 200f)
                {
                    print("Wrong timing");
                    NS.GotError();
                }
            }
        }


        if(_myTransform.position.y < -20f)
        {
            print("Missed");
            NS.GotError();
            Destroy(this.gameObject);
        }
    }
}
