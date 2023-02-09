using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace SpaceGame
{
    public class ItemInteractable : Interactable //Describes an item thats been dropped
    {
        private void Start()
        {
            if(!String.IsNullOrEmpty(_itemId))
            { 
                SetItemId(_itemId);
            }
        }
        public override bool CanInteract(Interactor interactor)
        {
            return base.CanInteract(interactor) && interactor.ItemHolder.ItemId == null; //not holding anything
        }
        protected override void OnInteractionFinished()
        {
            _currentInteractor.ItemHolder.SetItem(_itemId);
            base.OnInteractionFinished();
            Destroy(gameObject);
        }
        public void SetItemId(string id)
        {
            _itemId = id;
            _itemHolder.SetItem(_itemId);
        }

    [SerializeField] private string _itemId;
    [SerializeField] ItemHolder _itemHolder;
    }
}
