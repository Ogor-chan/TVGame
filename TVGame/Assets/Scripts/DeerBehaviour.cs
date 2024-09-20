using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerBehaviour : MonoBehaviour
{
    private float _timeAlive;
    public DeerMinigame DM;
    void Update()
    {
        _timeAlive += Time.deltaTime;
        if(_timeAlive >= 2f)
        {
            DM.Lost();
            Destroy(this.gameObject);
        }
    }
}
