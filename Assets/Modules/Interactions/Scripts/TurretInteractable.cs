namespace SpaceGame
{
    public class TurretInteractable : Interactable
    {
        public override bool CanInteract(Interactor interactor)
        {
            return base.CanInteract(interactor) && interactor.ItemHolder.ItemId == "ammo";
        }

        protected override void OnInteractionFinished()
        {
            _currentInteractor.ItemHolder.SetItem(null);
            _taskManager.CompleteCurrentTask();
            base.OnInteractionFinished();
        }

        private void Awake()
        {
            _taskManager = GetComponent<TurretTaskManager>();
        }

        private TurretTaskManager _taskManager;
    }
}