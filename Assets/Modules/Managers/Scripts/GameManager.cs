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
            AddScore();
        }
        
        private void AddScore()
        {
            _score++;
            _scoreEvent.RaiseEvent(_score);
        }

        [SerializeField] private GameUI _gameUI;
        [SerializeField] IntEventChannel _scoreEvent;
        [SerializeField] VoidEventChannel _taskCompleteEvent;
        [SerializeField] VoidEventChannel _taskFailEvent;

        int _score;
        [SerializeField]
        float _currentHp;
        [SerializeField]
        float _maxHp;
    }
}