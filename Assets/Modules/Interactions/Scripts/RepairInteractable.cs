using System;
using UnityEngine;

namespace SpaceGame
{
    public class RepairInteractable : Interactable
    {
        public bool IsRepaired => _isRepaired;

        public void Repair()
        {
            _isRepaired = true;
            _meshRenderer.material = _repairedMaterial;
        }

        public void Break()
        {
            _isRepaired = false;
            _meshRenderer.material = _defaultMaterial;
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

        [SerializeField] private bool _isRepaired;
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private Material _repairedMaterial;
        private Material _defaultMaterial;
    }
}