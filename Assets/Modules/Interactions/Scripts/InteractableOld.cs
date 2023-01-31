using System.Collections.Generic;
using UnityEngine;

namespace SpaceGame
{
    public abstract class InteractableOld : MonoBehaviour
    {
        public static List<InteractableOld> Interactables = new();
        public float Range => _range;
        
        public virtual bool CanInteract(InteractorOld interactor) => true;
        public virtual void SetActive(bool active) => _bubble.SetActive(active);
        public void Interact(InteractorOld interactor) => OnInteract(interactor);
        public void Cancel(InteractorOld interactor) => OnCancel(interactor);

        protected virtual void OnInteract(InteractorOld interactor)
        {
            // Do bubble animations and stuff
            // if (interactor.ShowBubbles)
            //     _bubble.Blink();
            // if (_interactClip)
            //     _interactClip.Play(transform.position);
        }
        
        protected virtual void OnCancel(InteractorOld interactor)
        {
            // Do bubble animations and stuff
            // if (interactor.ShowBubbles)
            //     _bubble.Blink();
            // if (_interactClip)
            //     _interactClip.Play(transform.position);
        }

        private void OnEnable() => Interactables.Add(this);
        private void OnDisable() => Interactables.Remove(this);

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _range);
        }

        [SerializeField]
        private float _range;
        [SerializeField]
        protected InteractableBubble _bubble;
    }
}