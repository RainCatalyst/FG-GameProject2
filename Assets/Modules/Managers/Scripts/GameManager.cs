using UnityEngine;

namespace SpaceGame
{
    public class GameManager : MonoSingleton<GameManager>
    {
        protected override void Awake()
        {
            base.Awake();
            _allyHp = _startAllyHp;
            _enemyHp = _startEnemyHp;
        }

        public void DealAllyDamage(int damage)
        {
            _allyHp -= damage;
            _gameUI.UpdateAllyHP(_allyHp / _startAllyHp);
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