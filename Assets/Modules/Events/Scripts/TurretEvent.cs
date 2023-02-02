using System;
using System.Linq;
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
            _interactable.TurretStuff += OnComplete;

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
            _interactable.TurretStuff -= OnComplete;
            base.OnComplete();
        }

        protected override void OnProgress()
        {
            base.OnProgress();
        }

        private TurretInteractable _interactable;
    }
}