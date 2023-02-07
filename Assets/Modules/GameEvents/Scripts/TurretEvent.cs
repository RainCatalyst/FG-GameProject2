using UnityEngine;

namespace SpaceGame
{
    public class TurretEvent : BaseEvent
    {
        public TurretEvent (TurretInteractable interactable)
        {
            _interactable = interactable;
        }

        public override void Begin()
        {
            base.Begin();
            // _interactable.OutOfAmmo += OnFail;
            // _interactable.AmmoRefilled += OnComplete;
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