using UnityEngine;

namespace SpaceGame
{
    public class DispenserInteractable : Interactable
    {
        public override bool CanInteract(Interactor interactor)
        {
            return base.CanInteract(interactor) && interactor.ItemHolder.ItemId == null;
        }        
        
        protected override void OnInteractionFinished()
        {
            _currentInteractor.ItemHolder.SetItem(_itemId);
            base.OnInteractionFinished();
        }

        [SerializeField] private string _itemId;
    }
}