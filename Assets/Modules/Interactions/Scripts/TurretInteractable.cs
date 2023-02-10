namespace SpaceGame
{
    public class TurretInteractable : Interactable
    {
        public override bool CanInteract(Interactor interactor)
        {
            return base.CanInteract(interactor) && _taskManager.CanDeliverTaskItem(interactor.ItemHolder.ItemId);
        }

        protected override void OnInteractionFinished()
        {
            _currentInteractor.ItemHolder.SetItem(null);
            _taskManager.DeliverTaskItem();
            base.OnInteractionFinished();
        }

        private void Awake()
        {
            _taskManager = GetComponent<TurretTaskManager>();
        }

        private TurretTaskManager _taskManager;
    }
}