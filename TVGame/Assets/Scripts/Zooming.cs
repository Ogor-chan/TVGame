using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zooming : MonoBehaviour
{

    [SerializeField] private Animator _animator;
    [SerializeField] private Animator _animator1;

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
            print("ye");
            _animator1.Play("StaticAnimation");
        }
    }

}
