using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceGame
{
    public class ItemInteractable : Interactable
    {
        public override bool CanInteract(Interactor interactor)
        {
            return base.CanInteract(interactor);
        }
        protected override void OnInteractionFinished()
        {
            _currentInteractor.ItemHolder.SetItem(_itemId);
            base.OnInteractionFinished();
        }
    [SerializeField] private string _itemId;
    }
}
