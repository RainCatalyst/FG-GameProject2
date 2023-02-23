using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceGame
{
    public class EncounterManager : MonoSingleton<EncounterManager>
    {
        public event Action EncounterChanged;
        public static EncounterData CurrentEncounter => Instance._encounters[Instance._encounterIndex];

        protected override void Awake()
        {
            base.Awake();
        }

        private IEnumerator Start()
        {
            yield return null;
            UpdateEncounter();
        }
        
        private void OnEnable()
        {
            _railgunFireEvent.EventRaised += OnRailgunFired;
        }

        private void OnDisable()
        {
            _railgunFireEvent.EventRaised -= OnRailgunFired;
        }
        
        // Shooting railgun should damage the ship
        private void OnRailgunFired()
        {
            _enemyHp--;
            _enemyHealthBar.Progress = (float)_enemyHp / CurrentEncounter.EnemyHp;
            if (_enemyHp <= 0)
            {
                _encounterIndex = Mathf.Clamp(_encounterIndex + 1, 0, _encounters.Length - 1);
                CameraControl.Instance.Shake();
                GameManager.Instance.AddScore(10);
                UpdateEncounter();
            }
        }

        private void UpdateEncounter()
        {
            _enemyHp = CurrentEncounter.EnemyHp;
            _enemyHealthBar.Progress = 1;
            // Notify others
            EncounterChanged?.Invoke();
        }

        // Manage enemy hp, track current encounter
        [SerializeField]
        private EncounterData[] _encounters; // sequence of all encounters in the game
        [SerializeField]
        private ProgressBar _enemyHealthBar;
        private int _encounterIndex; // index of current encounter?
        private int _enemyHp;
        [Header("Events")]
        [SerializeField] private VoidEventChannel _railgunFireEvent;
    }
}
