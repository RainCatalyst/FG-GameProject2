using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SpaceGame
{
    public class CombinerInteractable : Interactable
    {
        public override bool CanInteract(Interactor interactor) 
        {
            if (!base.CanInteract(interactor)) //if its NOT null or NOT matches the interactor we need....?
            {
                return false;
            }

            if (interactor.ItemHolder.ItemId == null && CanPickup() && _detector.AreBothPlayersIn) //if were not holding anything and the current items in the combiner is 2
            {
                return true;
            }
            
            if (CanAddItem(interactor.ItemHolder.ItemId))
            {
                return true; 
            }
            
            return false;
        }        
        
        protected override void OnInteractionFinished()
        {
            if (CanPickup())
            {
                _currentInteractor.ItemHolder.SetItem(GetResult());
                foreach (var itemHolder in _itemHolders)
                {
                    itemHolder.SetItem(null);
                }
                _items.Clear();
            }
            else
            {
                AddItem(_currentInteractor.ItemHolder.ItemId);
                _currentInteractor.ItemHolder.SetItem(null);
            }
            base.OnInteractionFinished();
        }
        
        private void Awake()
        {
            _items = new List<string>();
        }

        private bool CanAddItem(string id) 
        {
            if (id == null)
            {
                return false;
            }
            
            var newItems = _items.Append(id).ToList();
            foreach (var recipe in _recipes)
            {
                if (recipe.OverlapsItems(newItems))
                {
                    return true;
                }
            }

            return false;
        }

        private void AddItem(string id)
        {
            _items.Add(id);
            _itemHolders[_items.Count - 1].SetItem(id);
        }

        private string GetResult()
        {
            foreach (var recipe in _recipes)
            {
                if (recipe.CanCraft(_items))
                {
                    return recipe.Result;
                }
            }

            return null;
        }
        
        private bool CanPickup() => GetResult() != null;

        [SerializeField]
        private List<RecipeData> _recipes;
        [SerializeField] private List<ItemHolder> _itemHolders;
        [SerializeField] private PlayerDetector _detector;
        
        private List<string> _items;
    }
}