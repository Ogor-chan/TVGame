using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBehaviour : MonoBehaviour
{
    private float _fallingSpeed = 500f;
    public int _whichButton;
    [SerializeField] private RectTransform _myTransform;
    private NoteSpawning NS;
    private RectTransform RT;
    private void Start()
    {
        NS = GameObject.Find("NoteSpawner").GetComponent<NoteSpawning>();
        RT = GetComponent<RectTransform>();
    }

    // 0 - Left
    // 1 - Up
    // 2 - Down
    // 3 - Right

    void Update()
    {
        ///Ye ye a tone of if statements inside an update function in a 
        ///frequently spawning prefab, not my proudest work
        ///
        RT.anchoredPosition = new Vector3(RT.anchoredPosition.x,
            RT.anchoredPosition.y - _fallingSpeed * Time.deltaTime,0);

        if(_whichButton == 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if(RT.anchoredPosition.y < -350f && RT.anchoredPosition.y > -600f)
                {
                    Destroy(this.gameObject);
                }
                else if (RT.anchoredPosition.y < -200f)
                {
                    print("Wrong timing");
                    NS.GotError();
                    Destroy(this.gameObject);
                }
            }
        }
        else if (_whichButton == 1)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (RT.anchoredPosition.y < -350f && RT.anchoredPosition.y > -600)
                {
                    Destroy(this.gameObject);
                }
                else if (RT.anchoredPosition.y < -200f)
                {
                    print("Wrong timing");
                    NS.GotError();
                    Destroy(this.gameObject);
                }
            }
        }
        else if (_whichButton == 2)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (RT.anchoredPosition.y < -350f && RT.anchoredPosition.y > -600)
                {
                    Destroy(this.gameObject);
                }
                else if (RT.anchoredPosition.y < -200f)
                {
                    print("Wrong timing");
                    NS.GotError();
                    Destroy(this.gameObject);
                }
            }
        }
        else if (_whichButton == 3)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (RT.anchoredPosition.y < -350f && RT.anchoredPosition.y > -600)
                {
                    Destroy(this.gameObject);
                }
                else if (RT.anchoredPosition.y < -200f)
                {
                    print("Wrong timing");
                    NS.GotError();
                    Destroy(this.gameObject);
                }
            }
        }


        if(RT.anchoredPosition.y < -600f)
        {
            print("Missed");
            NS.GotError();
            Destroy(this.gameObject);
        }
    }
}
