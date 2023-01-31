using System;
using UnityEngine;

namespace SpaceGame
{
    // This class will interact with interactables
    public class Interactor : MonoBehaviour
    {
        public event Action InteractionStarted; 
        public event Action InteractionFinished; 

        public void TryInteract()
        {
            // Try to interact with the closest interactable if available
            if (_closestInteractable != null)
            {
                _closestInteractable.Interact(this);
                _currentInteractable = _closestInteractable;
                InteractionStarted?.Invoke();
            }
        }

        public void CancelInteract()
        {
            // Cancel current interaction
            if (_currentInteractable != null)
            {
                _currentInteractable.Cancel(this);
                InteractionFinished?.Invoke();
                _currentInteractable = null;
            }
        }

        public void FinishInteraction()
        {
            InteractionFinished?.Invoke();
            _currentInteractable = null;
        }

        private void Update()
        {
            var newInteractable = FindClosestInteractable();

            if (newInteractable != null)
            {
                if (newInteractable != _closestInteractable)
                {
                    if (_closestInteractable != null)
                        _closestInteractable.ToggleBubble(false);
                    newInteractable.ToggleBubble(true);
                }
            }
            else
            {
                if (_closestInteractable != null)
                    _closestInteractable.ToggleBubble(false);
            }

            _closestInteractable = newInteractable;
        }

        private Interactable FindClosestInteractable()
        {
            // Go through every interactable in the game and find the closest available one
            float minDistance = float.MaxValue;
            Interactable closest = null;
            
            foreach (var interactable in Interactable.Interactables)
            {
                float distance = Vector3.Distance(transform.position, interactable.transform.position);
                if (distance <= interactable.Range && interactable.CanInteract(this) && distance < minDistance)
                {
                    minDistance = distance;
                    closest = interactable;
                }
            }

            return closest;
        }

        private Interactable _currentInteractable;
        private Interactable _closestInteractable;
    }
}