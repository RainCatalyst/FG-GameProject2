using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SpaceGame
{
    public class CombinerInteractable : Interactable
    {
        public override bool CanInteract(Interactor interactor) 
        {
            if(!base.CanInteract(interactor)) //if its NOT null or NOT matches the interactor we need....?
            {
                return false;
            }
                
            if (interactor.ItemHolder.ItemId == null && CanPickup()) //if were not holding anything and the current items in the combiner is 2
            {
                return true;
            }
            else if (CanAddItem(interactor.ItemHolder.ItemId))
            {
                return true; 
            }
            else
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

            if (_items.Count > 0)
            {
                foreach (var recipe in _recipes)
                {
                    // We have other item in the recipe
                    if (recipe.RequiredItems.Contains(_items[0]))
                    {
                        string requiredItemId = null;
                        foreach (string itemId in recipe.RequiredItems)
                        {
                            if (itemId != _items[0])
                            {
                                requiredItemId = itemId;
                            }
                        }

                        if (requiredItemId != null && requiredItemId == id)
                        {
                            return true; 
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
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