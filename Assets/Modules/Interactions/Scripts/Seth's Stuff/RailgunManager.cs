using System;
using System.Collections;
using System.Collections.Generic;
using SpaceGame;
using UnityEngine;

namespace SpaceGame
{
    public class RailgunManager : MonoBehaviour
    {
        private void Awake()
        {
            _railgunFireEvent.EventRaised += OnRailgunFire;
        }

        private void Update()
        {
            if (!_readyToFire)
            {
                _timer += Time.deltaTime;
                _launchBar.Progress = 0f + _timer / _timeUntilFire;
                if (_timer >= _timeUntilFire)
                {
                    _readyToFire = true;
                    print("Charged!");
                    _railgunChargedEvent.RaiseEvent();
                }
            }
        }
        
        private void OnRailgunFire()
        {
            // Particles, reset timer etc
            _readyToFire = false;
            _timer = 0;
            print("Fire!!!!");
        }

        public float _timer;
        public bool _readyToFire;
        [SerializeField]
        private float _timeUntilFire;
        [SerializeField]
        private ProgressBar _launchBar;
        [SerializeField]
        private VoidEventChannel _railgunFireEvent;
        [SerializeField]
        private VoidEventChannel _railgunChargedEvent;
    }
}