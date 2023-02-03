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

        private RepairInteractable _interactable;
    }
}