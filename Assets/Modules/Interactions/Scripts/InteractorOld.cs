using System;
using UnityEngine;

namespace SpaceGame
{
    public class InteractorOld : MonoBehaviour
    {
        public InteractableOld ClosestInteractable => _closestInteractable;
        public bool CanInteract() => _closestInteractable && _closestInteractable.CanInteract(this);

        public void Interact()
        {
            if (!CanInteract()) return;
            
            _closestInteractable.Interact(this);
        }

        private void Update()
        {
            var newInteractable = FindInteractable();
            if (newInteractable != _closestInteractable)
            {
                _closestInteractable?.SetActive(false);
                if (newInteractable && newInteractable.CanInteract(this))
                    newInteractable.SetActive(true);
                _closestInteractable = newInteractable;
            }
            else
            {
                bool canInteractNow = CanInteract();

                if (_canInteractBefore != canInteractNow)
                {
                    _closestInteractable?.SetActive(canInteractNow);
                    _canInteractBefore = canInteractNow;
                }
            }
        }

        // private void OnDrawGizmosSelected()
        // {
        //     Handles.matrix = transform.localToWorldMatrix;
        //     Vector3 from = Quaternion.AngleAxis(-_allowedAngle * 0.5f, Vector3.forward) * Vector3.up;
        //     Handles.DrawWireArc(Vector3.zero, Vector3.forward, from, _allowedAngle, 1f);
        // }

        private InteractableOld FindInteractable()
        {
            float minDistance = float.MaxValue;
            InteractableOld closest = null;
            foreach (var interactable in InteractableOld.Interactables)
            {
                float distance = Vector3.Distance(interactable.transform.position , transform.position);
                if (distance <= interactable.Range && distance <= minDistance)
                {
                    minDistance = distance;
                    closest = interactable;
                }
            }

            return closest;
        }

        private InteractableOld _closestInteractable;
        private bool _canInteractBefore;

        [SerializeField]
        private float _allowedAngle;
        [SerializeField]
        private bool _ignoreAngle;
        [SerializeField]
        private bool _showBubbles;
    }
}