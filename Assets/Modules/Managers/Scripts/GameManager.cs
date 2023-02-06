using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceGame
{
    public class GameManager : MonoSingleton<GameManager>
    {
        [SerializeField] IntEventChannelSO scoreEvent; //change

        int score; //change
        protected override void Awake()
        {
            scoreEvent.OnValueAdded += OnScoreAdded; //change
            base.Awake();
            _allyHp = _startAllyHp;
            _enemyHp = _startEnemyHp;
        }
        void OnScoreAdded() //change
        {
            score++;
            scoreEvent.UpdateValue(score);
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

        public void DealAllyDamage(int damage)
        {
            _allyHp -= damage;
            _gameUI.UpdateAllyHP(_allyHp / _startAllyHp);

            if (_allyHp <= 0)
            {
                GameOver();
            }
            print($"Dealt {damage} to ally, left: {_allyHp}");
            // Update UI, trigger lose in case allyHp goes to 0
        }
        
        public void DealEnemyDamage(int damage)
        {
            _enemyHp -= damage;
            _gameUI.UpdateEnemyHP(_enemyHp / _startEnemyHp);
            print($"Dealt {damage} to enemy, left: {_enemyHp}");
            // Update UI, trigger win in case enemyHp goes to 0
        }

        [SerializeField] private int _startAllyHp = 10;
        [SerializeField] private int _startEnemyHp = 10;

        [SerializeField] private GameUI _gameUI;

        private float _allyHp;
        private float _enemyHp;
    }
}