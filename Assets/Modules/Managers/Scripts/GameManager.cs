using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceGame
{
    public class GameManager : MonoSingleton<GameManager>
    {
        protected override void Awake()
        {
            // TODO: Make sure we properly dispose of events later
            _allyHealth.Setup();
            _enemyHealth.Setup();
            _scoreEvent.RaiseEvent(_score);
            base.Awake();
            Time.timeScale = 1;
        }

        private void OnEnable()
        {
            _taskCompleteEvent.EventRaised += OnTaskCompleted;
            _taskFailEvent.EventRaised += OnTaskFailed;
            _railgunFireEvent.EventRaised += OnRailgunFired;
            _outOfOxygenEvent.EventRaised += OnOutOfOxygen;
            _allyHealth.Died += GameOver;
        }

        private void OnDisable()
        {
            _taskCompleteEvent.EventRaised -= OnTaskCompleted;
            _taskFailEvent.EventRaised -= OnTaskFailed;
            _railgunFireEvent.EventRaised -= OnRailgunFired;
            _outOfOxygenEvent.EventRaised -= OnOutOfOxygen;
            _allyHealth.Died -= GameOver;
        }

        public void Restart()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Game");
        }

        public void GameOver()
        {
            _gameUI.ShowGameOver();
            Time.timeScale = 0f;
        }

        private void OnTaskCompleted()
        {
            // Do nothing for now
            _score += 1;
            _scoreEvent.RaiseEvent(_score);
        }
        
        private void OnTaskFailed()
        {
            // Deal damage to the player's ship
            // _allyHealth.DealDamage(1);
            CameraShake.Instance.Shake();
            RepairManager.Instance.BreakRandom();
        }
        
        private void OnRailgunFired()
        {
            _enemyHealth.DealDamage(1);
        }

        private void OnOutOfOxygen()
        {
            GameOver();
        }

        private int _score = 0;

        [SerializeField] private GameUI _gameUI;
        [Header("Health")]
        [SerializeField] private HealthData _allyHealth;
        [SerializeField] private HealthData _enemyHealth;
        [Header("Events")]
        [SerializeField] private VoidEventChannel _taskCompleteEvent;
        [SerializeField] private VoidEventChannel _taskFailEvent;
        [SerializeField] private VoidEventChannel _railgunFireEvent;
        [SerializeField] private VoidEventChannel _outOfOxygenEvent;
        [SerializeField] private IntEventChannel _scoreEvent;
    }
}