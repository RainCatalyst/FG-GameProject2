using UnityEngine;

namespace SpaceGame
{
    public class InteractableBubble : MonoBehaviour
    {
        public void SetActive(bool active)
        {
            // Do animations
            _active = active;
            _visuals.SetActive(active);
        }

        public void SetProgress(float progress)
        {
            transform.localScale = Vector3.one * (0.25f + progress * 0.75f);
        }

        [SerializeField] private GameObject _visuals;
        private bool _active;
    }
}