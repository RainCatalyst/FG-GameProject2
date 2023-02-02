using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceGame
{
    public class TurretInteractable : Interactable
    {
        public override bool CanInteract(Interactor interactor)
        {
            return base.CanInteract(interactor) && !_isFilled && interactor.ItemHolder.ItemId == "ammo";
        }
        protected override void OnInteractionStarted()
        {
            base.OnInteractionStarted();
        }

        protected override void OnInteractionFinished()
        {
            _isFilled = true;
            _currentInteractor.ItemHolder.SetItem(null);
            _ammoTimer = 10f;
            base.OnInteractionFinished();
        }
        protected override void Update()
        {
            base.Update();
            if (_isFilled && _ammoTimer >= 0f)
            {
                _ammoTimer -= Time.deltaTime;
                print(_ammoTimer + " Ammo is loaded");
                if (_ammoTimer <= 0f)
                    OutOfAmmo();
            }
        }

        private void OutOfAmmo()
        {
            print("Out of Ammo");
        }


        [SerializeField] private bool _isFilled;
        [SerializeField] private float _ammoTimer;
        private float _ammo;
    }
}