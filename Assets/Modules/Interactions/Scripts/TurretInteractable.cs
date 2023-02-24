using UnityEngine;

namespace SpaceGame
{
    public class TurretInteractable : Interactable
    {
        public override bool CanInteract(Interactor interactor)
        {
            bool canDeliver = _taskManager.CanDeliverTaskItem(interactor.ItemHolder.ItemId);
            if (interactor.ItemHolder.ItemId == null)
            {
                _icon.SetColor(Color.white);
            }
            else
            {
                _icon.SetColor(canDeliver ? _goodColor : _badColor);
            }

            return base.CanInteract(interactor) && canDeliver;
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
        [SerializeField]
        private Color _goodColor;
        [SerializeField]
        private Color _badColor;
    }
}