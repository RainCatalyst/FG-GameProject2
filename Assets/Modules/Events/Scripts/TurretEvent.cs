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
            _interactable.AmmoRefilled += OnComplete;
        }

        public override void End()
        {
            base.End();
        }

        protected override void OnFail()
        {
            // base.OnFail();
        }

        protected override void OnComplete()
        {
            // base.OnComplete();
        }

        private TurretInteractable _interactable;
    }
}