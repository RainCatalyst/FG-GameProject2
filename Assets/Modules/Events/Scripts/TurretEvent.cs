using UnityEngine;

namespace SpaceGame
{
    public class TurretEvent : BaseEvent
    {
        public TurretEvent (TurretInteractable interactable) //constructor
        {
            _interactable = interactable;
        }

        public override void Begin()
        {
            base.Begin();
            _isActive = true;
            _interactable.OutOfAmmo += OnFail;
            _interactable.AmmoRefilled += OnComplete;
        }

        public override void End()
        {
            base.End();
        }

        public override void Update()
        {
            if (_isActive)
            {
                // Deal damage to the enemy ship
                _timer += Time.deltaTime;
                if (_timer >= _damageDelay)
                {
                    GameManager.Instance.DealEnemyDamage(_damage);
                    _timer = 0;
                }
            }
        }

        protected override void OnFail()
        {
            Debug.Log("Turret out of ammo! Show warning!");
            _isActive = false;
            // base.OnFail();
        }

        protected override void OnComplete()
        {
            Debug.Log("Turret out of ammo! Show warning!");
            // Set failed flag to false
            _isActive = true;
            _timer = 0;
            // base.OnComplete();
        }

        private bool _isActive;
        private float _timer;
        private float _damageDelay = 5f;
        private int _damage = 1;
        private TurretInteractable _interactable;
    }
}