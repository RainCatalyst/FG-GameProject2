using System;
using System.Collections;
using System.Collections.Generic;
using SpaceGame;
using UnityEngine;

namespace SpaceGame
{
    public class RailgunManager : MonoBehaviour
    {
        public void Fire()
        {
            StartCoroutine(CoFire());
        }
        
        private void Update()
        {
            if (GameManager.Instance.IsGameplayPaused)
                return;
            if (!_readyToFire)
            {
                _timer += Time.deltaTime;
                _launchBar.Progress = 0f + _timer / _timeUntilFire;
                if (_timer >= _timeUntilFire)
                {
                    _readyToFire = true;
                    _railgunChargedEvent.RaiseEvent();
                }
            }

            if (_readyToFire)
            {
                _launchBar.ProgressFill.color = Color.green;
            }
            else
            {
                _launchBar.ProgressFill.color = Color.yellow;
            }
        }

        private IEnumerator CoFire()
        {
            _railgunFireEvent.RaiseEvent();
            _readyToFire = false;
            _timer = 0;
            CameraControl.Instance.OverrideTarget = _cameraTarget;
            CameraControl.Instance.Shake();
            _vfx.Play();
            GameManager.Instance.ToggleGameplayPause(true);
            yield return new WaitForSeconds(3.75f);
            CameraControl.Instance.OverrideTarget = null;
            GameManager.Instance.ToggleGameplayPause(false);
        }

        public float _timer;
        public bool _readyToFire;
        [SerializeField]
        private float _timeUntilFire;
        [SerializeField]
        private ProgressBar _launchBar;
        [SerializeField]
        private RailgunVFX _vfx;
        [SerializeField]
        private Transform _cameraTarget;
        [SerializeField]
        private VoidEventChannel _railgunFireEvent;
        [SerializeField]
        private VoidEventChannel _railgunChargedEvent;
    }
}