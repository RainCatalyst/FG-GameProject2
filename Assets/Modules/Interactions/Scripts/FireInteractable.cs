using UnityEngine;
using System;

namespace SpaceGame
{
    public class FireInteractable : Interactable //Describes an item thats been dropped
    {
        public override bool CanInteract(Interactor interactor)
        {
            return base.CanInteract(interactor) && interactor.CharacterType == CharacterType.Robot;
        }

        protected override void OnInteractionFinished()
        {
            base.OnInteractionFinished();
            _destroyFire.DestroySelf();
        }

        private void Awake()
        {
            _destroyFire = GetComponent<DestroyFire>();
        }

        private DestroyFire _destroyFire;
    }
}