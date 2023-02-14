using System;
using System.Collections;
using System.Collections.Generic;
using SpaceGame;
using UnityEngine;

public class RailgunManager : MonoBehaviour
{
    void Update()
    {

        if (!_readyToFire)
        {
            _timer += Time.deltaTime;
            _launchBar.Progress = 0f + _timer / _timeUntilFire;
            if (_timer >= _timeUntilFire)
            {
                _readyToFire = true;
            }
        }
    }

    public float _timer;
    public bool _readyToFire = false;
    [SerializeField] private float _timeUntilFire;
    [SerializeField] private ProgressBar _launchBar;
    
    
}
