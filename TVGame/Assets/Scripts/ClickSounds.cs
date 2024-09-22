using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickSounds : MonoBehaviour
{
    [SerializeField] private AudioClip normalClickSound;
    [SerializeField] private AudioClip uiClickSound;
    [SerializeField] private AudioSource AS;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (IsPointerOverUIElement())
            {
                AS.PlayOneShot(normalClickSound);
            }
            else
            {
                AS.PlayOneShot(uiClickSound);
            }
        }
    }

    private bool IsPointerOverUIElement()
    {
        if (EventSystem.current != null)
        {
            return EventSystem.current.IsPointerOverGameObject();
        }
        return false;
    }
}
