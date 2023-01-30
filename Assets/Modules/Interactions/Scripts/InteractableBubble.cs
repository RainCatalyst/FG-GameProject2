using UnityEngine;

namespace SpaceGame
{
    public class InteractableBubble : MonoBehaviour
    {
        public void SetActive(bool active)
        {
            // Do animations
            _active = active;
        }
        
        private bool _active;
    }
}