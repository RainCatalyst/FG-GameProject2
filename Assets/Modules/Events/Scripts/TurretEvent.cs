using UnityEngine;

namespace SpaceGame
{
    public class TurretEvent : BaseEvent
    {
        public TurretEvent (TurretInteractable interactable) //constructor
        {
            _interactable = interactable;
        }

        public override void Begin()
        {
            base.Begin();
            _interactable.OutOfAmmo += OnFail;
        }

        public override void End()
        {
            base.End();
        }

        protected override void OnFail()
        {
            Debug.Log("Turret out of ammo! Show warning!");
            // base.OnFail();
        }

        protected override void OnComplete()
        {
            base.OnComplete();
        }

        protected override void OnProgress()
        {
            base.OnProgress();
        }

        private TurretInteractable _interactable;
    }
}