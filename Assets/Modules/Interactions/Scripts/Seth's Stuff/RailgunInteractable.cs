using System;
using Unity.VisualScripting;
using UnityEngine;

namespace SpaceGame
{
    public class RailgunInteractable : Interactable
    {
        public override bool CanInteract(Interactor interactor)
        {
            // Base
            // ReadyToFire
            // No item
            // Character type
            
           //  if (_railgunManager._readyToFire)
           //  { 
           //      if (_characterType == CharacterType.Human)
           //     {
           //         return base.CanInteract(interactor) && interactor.ItemHolder.ItemId == null &&
           //                interactor.CharacterType == CharacterType.Human;
           //     }
           //
           // if(_railgunManager._readyToFire)
           //     if (_characterType == CharacterType.Robot)
           //     {
           //         return base.CanInteract(interactor) && interactor.ItemHolder.ItemId == null &&
           //                interactor.CharacterType == CharacterType.Robot;
           //     }

           return base.CanInteract(null);
        }

        protected override void OnInteractionFinished()
        {
            base.OnInteractionFinished();
            _railgunManager._readyToFire = false;
            _railgunManager._timer = 0f;
            Debug.Log("railgun interacted");
        }

        private void Awake()
        {
            
        }

        [SerializeField] private CharacterType _characterType;
        [SerializeField] private ProgressBar _launchBar;
        [SerializeField] private RailgunManager _railgunManager;

    }
}