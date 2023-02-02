using System;
using System.Linq;
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
        }

        public override void End()
        {
            base.End();
        }

        protected override void OnFail()
        {
            base.OnFail();
        }

        protected override void OnComplete()
        {
            base.OnComplete();
        }

        protected override void OnProgress()
        {
            base.OnProgress();
        }

        private RepairInteractable _interactable;
    }
}