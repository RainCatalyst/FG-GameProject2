using System;
using UnityEngine;

namespace SpaceGame
    //TODO: Drop current item, check if holding, spawning an iteminteractable
{
    // This class will interact with interactables
    public class Interactor : MonoBehaviour
    {
        public event Action InteractionStarted; 
        public event Action InteractionFinished;

        public bool CanInteract => _closestInteractable != null;
        public bool CanDropItem => _itemHolder.ItemId != null;
        public ItemHolder ItemHolder => _itemHolder;

        public void Setup(ItemHolder itemHolder)
        {
            _itemHolder = itemHolder;
        }

        public void Interact()
        {
            _closestInteractable.Interact(this);
            _currentInteractable = _closestInteractable;
            InteractionStarted?.Invoke();
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

        public void DropItem()
        {
            var itemId = _itemHolder.ItemId;
            _itemHolder.SetItem(null);
            var itemParent = _itemHolder.ItemParent;
            var droppedItem = Instantiate(_itemPrefab, itemParent.position, itemParent.rotation);
            droppedItem.SetItem(itemId);
            
            droppedItem.Throw((itemParent.forward - Vector3.up * 1f) * _throwForce);
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
                        _closestInteractable.RemoveInteractor();
                    newInteractable.AddInteractor();
                }
            }
            else
            {
                if (_closestInteractable != null)
                    _closestInteractable.RemoveInteractor();
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

        [SerializeField]
        private ItemInteractable _itemPrefab;
        [SerializeField]
        private float _throwForce;

        private Interactable _currentInteractable;
        private Interactable _closestInteractable;
        private ItemHolder _itemHolder;
    }
}