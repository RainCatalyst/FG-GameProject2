using UnityEngine;

namespace SpaceGame
{
    public class RepairEvent : BaseEvent
    {
        public RepairEvent(RepairInteractable interactable)
        {
            _interactable = interactable;
        }
        
        public override void Begin()
        {
            base.Begin();
            _interactable.Break();
            _interactable.Repaired += OnComplete;
            _interactable.Exploded += OnFail;
        }

        protected override void OnFail()
        {
            // base.OnFail();
        }

        protected override void OnComplete()
        {
            _interactable.Repaired -= OnComplete;
            base.OnComplete();
        }

        private RepairInteractable _interactable;
        private float _timer;
    }
}