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
        }

        public override void Update()
        {
            _timer += Time.deltaTime;
            if (_timer >= _timeUntilFailure)
            {
                GameManager.Instance.DealAllyDamage(_damage);
                _timer = 0;
            }
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
            _interactable.Repaired -= OnComplete;
            base.OnComplete();
        }

        protected override void OnProgress()
        {
            base.OnProgress();
        }

        private float _timeUntilFailure = 10f;
        private int _damage = 1;
        private RepairInteractable _interactable;
        private float _timer;
    }
}