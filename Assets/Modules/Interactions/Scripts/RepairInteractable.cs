using UnityEngine;

namespace SpaceGame
{
    public class RepairInteractable : Interactable
    {
        public override bool CanInteract(Interactor interactor)
        {
            return !_isRepaired;
        }

        protected override void OnInteractionStarted()
        {
            base.OnInteractionStarted();
            print("Repair started! Show particles and stuff!");
        }

        protected override void OnInteractionFinished()
        {
            base.OnInteractionFinished();
            _isRepaired = true;
            print("Repair finished! Show particles and stuff!");
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

        [SerializeField] private bool _isRepaired;
    }
}