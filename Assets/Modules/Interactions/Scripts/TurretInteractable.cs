using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceGame
{
    public class TurretInteractable : Interactable
    {
        public override bool CanInteract(Interactor interactor)
        {
            return base.CanInteract(interactor) && !_isFilled && interactor.ItemHolder.ItemId == "ammo";
        }

        protected override void OnInteractionStarted()
        {
            base.OnInteractionStarted();
        }

        protected override void OnInteractionFinished()
        {
            _isFilled = true;
            _currentInteractor.ItemHolder.SetItem(null);
            base.OnInteractionFinished();
        }
        protected override void OnInteractionCanceled()
        {
            base.OnInteractionCanceled();
            print("Cancel repair, zap the player with lightning! Ouch!");
        }
        protected override void OnInteractionUpdate()
        {
            base.OnInteractionUpdate();
            print("Repairing in progress...");
        }

        [SerializeField] private bool _isFilled;


    }
}
