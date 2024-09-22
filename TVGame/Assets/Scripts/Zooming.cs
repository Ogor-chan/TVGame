using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zooming : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    public void ZoomIn()
    {
        _animator.Play("ZoomingIn");

    }

    public void ZoomOut()
    {
        _animator.Play("ZoomingOut");

    }


}
