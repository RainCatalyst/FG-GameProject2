using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace SpaceGame
{
    public class TurretInteractable : Interactable
    {
        public event Action OutOfAmmo;

        public override bool CanInteract(Interactor interactor)
        {
            return base.CanInteract(interactor) && interactor.ItemHolder.ItemId == "ammo";
        }

        protected override void OnInteractionFinished()
        {
            _currentInteractor.ItemHolder.SetItem(null);
            _ammoTimer += _addAmmoTime;
            base.OnInteractionFinished();
        }
        
        protected override void Update()
        {
            base.Update();
            if (_ammoTimer > 0f)
            {
                _ammoTimer -= Time.deltaTime;
                if (_ammoTimer <= 0f)
                    RunOutOfAmmo();
            }
        }

        private void RunOutOfAmmo()
        {
            print("Out of Ammo");
            OutOfAmmo?.Invoke(); //Invoking an event. All listeners will do something.
            _ammoTimer = 0f;
        }
        
        [SerializeField] private float _addAmmoTime = 10f;
        private float _ammoTimer;
    }
}