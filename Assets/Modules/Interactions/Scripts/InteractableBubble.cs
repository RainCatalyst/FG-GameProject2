using UnityEngine;

namespace SpaceGame
{
    public class InteractableBubble : MonoBehaviour
    {
        public void SetActive(bool active)
        {
            _active = active;
            LeanTween.cancel(_visuals.gameObject);
            if (active)
            {
                SetProgress(0);
                LeanTween.scale(_visuals.gameObject, Vector3.one, 0.21f).setEaseOutBack();
            }
            else
            {
                LeanTween.scale(_visuals.gameObject, Vector3.zero, 0.21f).setEaseInBack();
            }
        }

        public void SetProgress(float progress)
        {
            _visuals.material.SetFloat("_Fill", progress * 0.9f);
        }

        [SerializeField]
        private MeshRenderer _visuals;
        private bool _active;
    }
}