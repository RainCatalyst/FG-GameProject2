using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceGame
{
    public class TurretInteractable : Interactable
    {
        public override bool CanInteract(Interactor interactor)
        {
            return base.CanInteract(interactor);
        }

        protected override void OnInteractionStarted()
        {
            base.OnInteractionStarted();
        }

        protected override void OnInteractionFinished()
        {
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
