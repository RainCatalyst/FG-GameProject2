using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SpaceGame
{
    public class CombinerInteractable : Interactable
    {
        public override bool CanInteract(Interactor interactor)
        {
            return base.CanInteract(interactor) && (CanAddItem(interactor.ItemHolder.ItemId) || CanPickup());
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

            return _recipes.Any(recipe => recipe.RequiredItems.Contains(id) && !_items.Contains(id));
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
                bool found = true;
                foreach (var item in _items)
                {
                    if (!recipe.RequiredItems.Contains(item))
                    {
                        found = false;
                        break;
                    }
                }

                if (found)
                {
                    return recipe.Result;
                }
            }

            return null;
        }

        // TODO: Connect to the recipe
        private bool CanPickup() => _items.Count == 2;

        [SerializeField]
        private List<RecipeData> _recipes;
        [SerializeField] private List<ItemHolder> _itemHolders;
        
        private List<string> _items;
    }
}