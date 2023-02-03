using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace SpaceGame
{
    public class TurretInteractable : Interactable
    {
        public event Action OutOfAmmo;
        public event Action AmmoRefilled;
        public event Action Shoot;

        public override bool CanInteract(Interactor interactor)
        {
            return base.CanInteract(interactor) && interactor.ItemHolder.ItemId == "ammo";
        }

        protected override void OnInteractionFinished()
        {
            _currentInteractor.ItemHolder.SetItem(null);
            if (_ammoTimer <= 0f)
            {
                AmmoRefilled?.Invoke();
            }
            _ammoTimer += _addAmmoTime;
            if (_ammoTimer > _maxTime)
                _ammoTimer = _maxTime;
            base.OnInteractionFinished();
        }
        
        protected override void Update()
        {
            base.Update();
            if (_ammoTimer > 0f)
            {
                _ammoTimer -= Time.deltaTime;
                _ammoBar.Progress = _ammoTimer / _maxTime;
                if (_ammoTimer <= 0f)
                    RunOutOfAmmo();
                
                // Deal damage to the enemy ship
                _shootTimer += Time.deltaTime;
                if (_shootTimer >= _shootDelay)
                {
                    GameManager.Instance.DealEnemyDamage(_damage);
                    _shootTimer = 0;
                    Shoot?.Invoke();
                }
            }
        }

        private void RunOutOfAmmo()
        {
            _ammoBar.Progress = 0;
            OutOfAmmo?.Invoke();
            _ammoTimer = 0f;
        }
        
        [Header("Ammo")]
        [SerializeField] private float _addAmmoTime = 10f;
        [SerializeField] private float _maxTime = 30f;
        [SerializeField] private ProgressBar _ammoBar;
        [Header("Shooting")]
        [SerializeField] private float _shootDelay = 5f;
        [SerializeField] private int _damage = 1;
        private float _shootTimer;
        private float _ammoTimer;
    }
}