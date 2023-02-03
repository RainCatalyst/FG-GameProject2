using UnityEngine;

namespace SpaceGame
{
    public class GameUI : MonoBehaviour
    {
        public void UpdateAllyHP(float value) => _allyHealthBar.Progress = value;
        public void UpdateEnemyHP(float value) => _enemyHealthBar.Progress = value;

        [SerializeField] private ProgressBar _allyHealthBar;
        [SerializeField] private ProgressBar _enemyHealthBar;
    }
}