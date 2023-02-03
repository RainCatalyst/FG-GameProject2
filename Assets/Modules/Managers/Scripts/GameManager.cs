using UnityEngine;

namespace SpaceGame
{
    public class GameManager : MonoSingleton<GameManager>
    {
        public void DealAllyDamage(int damage)
        {
            _allyHp -= damage;
            // Update UI, trigger lose in case allyHp goes to 0
        }
        
        public void DealEnemyDamage(int damage)
        {
            _enemyHp -= damage;
            // Update UI, trigger win in case enemyHp goes to 0
        }

        [SerializeField] private int _startAllyHp = 10;
        [SerializeField] private int _startEnemyHp = 10;
        
        private float _allyHp;
        private float _enemyHp;
    }
}