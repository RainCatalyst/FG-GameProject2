using UnityEngine;

namespace SpaceGame
{
    public class GameUI : MonoBehaviour
    {
        public void UpdateAllyHP(float value) => _allyHealthBar.Progress = value;
        public void UpdateEnemyHP(float value) => _enemyHealthBar.Progress = value;

        public void ShowGameOver() => _gameOverMenu.SetActive(true);

        public void OnRestart()
        {
            GameManager.Instance.Restart();
        }

        [SerializeField] private ProgressBar _allyHealthBar;
        [SerializeField] private ProgressBar _enemyHealthBar;
        [SerializeField] private GameObject _gameOverMenu;
    }
}