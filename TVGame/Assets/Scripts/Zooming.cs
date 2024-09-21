using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zooming : MonoBehaviour
{

    [SerializeField] private Animator _animator;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            _animator.Play("ZoomingIn");

        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            _animator.Play("ZoomingOut");

        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            _animator.Play("StaticAnimation");
        }
    }

}
