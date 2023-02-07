using System.Collections.Generic;
using UnityEngine;

namespace SpaceGame
{
    public class CombinerInteractable : Interactable
    {
        public override bool CanInteract(Interactor interactor)
        {
            return base.CanInteract(interactor) && (TryAddItem(interactor.ItemHolder.ItemId) || CanPickup());
        }        
        
        protected override void OnInteractionFinished()
        {
            _currentInteractor.ItemHolder.SetItem(CanPickup() ? _resultId : null);
            foreach (var itemHolder in _itemHolders)
            {
                itemHolder.SetItem(null);
            }
            base.OnInteractionFinished();
        }
        private void Awake()
        {
            _items = new List<string>();
        }
        private bool TryAddItem(string id)
        {
            if (id == null)
            {
                return false;
            }
            if (_requiredItems.Contains(id) && !_items.Contains(id))
            {
                _items.Add(id);
                _itemHolders[_items.Count - 1].SetItem(id);
                return true;
            }

            return false;
        }

        private bool CanPickup() => _items.Count == _requiredItems.Count;

        [SerializeField] private List<string> _requiredItems;
        [SerializeField] private string _resultId;
        [SerializeField] private List<ItemHolder> _itemHolders;
        
        private List<string> _items;
    }
}