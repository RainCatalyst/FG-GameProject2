using System;
using UnityEngine;

namespace SpaceGame
{
    public class DispenserInteractable : Interactable
    {
        private void Start()
        {
            EncounterManager.Instance.EncounterChanged += OnEncounterChanged;
        }

        private void OnEncounterChanged()
        {
            // Disable if we are dispensing special ammo and current encounter doesn't allow that
            IsDisabled = ItemDatabase.Get(_itemId).IsSpecialAmmo && !EncounterManager.CurrentEncounter.AllowSpecialAmmo;
        }

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