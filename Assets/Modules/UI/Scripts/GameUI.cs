using UnityEngine;

namespace SpaceGame
{
    public class GameUI : MonoBehaviour
    {
        public void ShowGameOver() => _gameOverMenu.Show();
        public void FadeControls() => _controlHint.FadeOut();
        public void ShowControls() => _controlHint.gameObject.SetActive(true);

        public void OnRestart()
        {
            GameManager.Instance.Restart();
        }
        
        [SerializeField] private GameOverUI _gameOverMenu;
        [SerializeField] private ControlsHint _controlHint;
    }
}