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
            _taskCompleteEvent.EventRaised += OnTaskCompleted;
            _taskFailEvent.EventRaised += OnTaskFailed;
            
            _allyHealth.Setup();
            _enemyHealth.Setup();
            _allyHealth.Died += GameOver;
            base.Awake();
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
        }
        
        private void OnTaskFailed()
        {
            // Deal damage to the player's ship
            _allyHealth.DealDamage(1);
            CameraShakeTest.Instance.Shake();
        }

        [SerializeField] private GameUI _gameUI;
        [Header("Health")]
        [SerializeField] private HealthData _allyHealth;
        [SerializeField] private HealthData _enemyHealth;
        [Header("Events")]
        [SerializeField] private VoidEventChannel _taskCompleteEvent;
        [SerializeField] private VoidEventChannel _taskFailEvent;
    }
}