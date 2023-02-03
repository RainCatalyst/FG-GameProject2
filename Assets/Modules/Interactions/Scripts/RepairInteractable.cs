using System;
using UnityEngine;

namespace SpaceGame
{
    public class RepairInteractable : Interactable
    {
        public event Action Repaired;
        public event Action Exploded;
        public bool IsRepaired => _isRepaired;

        public void Repair()
        {
            _isRepaired = true;
            _meshRenderer.material = _repairedMaterial;
            _escalationBar.gameObject.SetActive(false);
            Repaired?.Invoke();
        }

        public void Break()
        {
            _isRepaired = false;
            _meshRenderer.material = _defaultMaterial;
            _escalationBar.gameObject.SetActive(true);
        }
        
        public override bool CanInteract(Interactor interactor)
        {
            return base.CanInteract(interactor) && !_isRepaired && interactor.ItemHolder.ItemId == "repairkit";
        }

        protected override void OnInteractionFinished()
        {
            Repair();
            _currentInteractor.ItemHolder.SetItem(null);
            base.OnInteractionFinished();
        }

        private void Awake()
        {
            _defaultMaterial = _meshRenderer.material;
            Repair();
        }

        protected override void Update()
        {
            base.Update();
            _timer += Time.deltaTime;
            _escalationBar.Progress = 1f - _timer / _timeUntilFailure;
            if (_timer >= _timeUntilFailure)
            {
                GameManager.Instance.DealAllyDamage(_damage);
                _timer = 0;
                Exploded?.Invoke();
            }
        }

        [SerializeField] private bool _isRepaired;
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private Material _repairedMaterial;
        [SerializeField] private ProgressBar _escalationBar;
        [SerializeField] private float _timeUntilFailure = 10f;
        [SerializeField] private int _damage = 1;
        private float _timer;
        private Material _defaultMaterial;
    }
}