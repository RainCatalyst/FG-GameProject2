using UnityEngine;

namespace SpaceGame
{
    public class GameUI : MonoBehaviour
    {
        public void ShowGameOver() => _gameOverMenu.Show();

        public void OnRestart()
        {
            GameManager.Instance.Restart();
        }
        
        [SerializeField] private GameOverUI _gameOverMenu;
    }
}