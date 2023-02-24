using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceGame
{
    public class InteractableIcon : MonoBehaviour
    {
        public void SetActive(bool active)
        {
            _active = active;
            LeanTween.cancel(gameObject);
            if (active)
            {
                LeanTween.scale(gameObject, Vector3.one, 0.21f).setEaseOutBack();
            }
            else
            {
                LeanTween.scale(gameObject, Vector3.zero, 0.21f).setEaseInBack();
            }
        }

        public void Ping()
        {
            LeanTween.cancel(gameObject);
            transform.localScale = Vector3.one;
            LeanTween.color(_image, Color.green, 0.25f).setLoopPingPong(1).setEaseInQuad(); 
        }

        [SerializeField]
        private RectTransform _image;
        private bool _active;
    }
}