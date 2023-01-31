using System;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceGame
{
    public class Interactable : MonoBehaviour
    {
        public static List<Interactable> Interactables = new();
        public float Range => _range;
        
        public bool CanInteract(Interactor interactor) => true;

        public void ToggleBubble(bool show) => _bubble.SetActive(show);
        
        public void Interact(Interactor interactor)
        {
            _currentInteractor = interactor;
            OnInteractionStarted();
        }

        public void Cancel(Interactor interactor)
        {
            OnInteractionCanceled();
            _currentInteractor = null;
        }

        protected void OnInteractionStarted()
        {
            // This happens when we start the interaction
            _interactionTimer = 0;
        }
        
        protected void OnInteractionFinished()
        {
            // This happens when we complete the interaction
            _currentInteractor.FinishInteraction();
            _currentInteractor = null;
        }

        protected void OnInteractionCanceled()
        {
            // This happens when we cancel the interaction
            print("Hey I cancled interaction!");
        }

        protected void OnInteractionUpdate()
        {
            // This happens every frame while interacting
            _interactionTimer += Time.deltaTime;
            
            print($"Interaction time: {_interactionTimer}");
            if (_interactionTimer >= _duration)
            {
                OnInteractionFinished();
            }

            float progress = Mathf.Clamp01(_interactionTimer / _duration);
            _bubble.SetProgress(progress);
        }

        private void OnEnable() => Interactables.Add(this);
        private void OnDisable() => Interactables.Remove(this);

        private void Update()
        {
            if (_currentInteractor != null)
            {
                OnInteractionUpdate();
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _range);
        }

        [SerializeField] private float _range = 1f;
        [SerializeField] private float _duration = 1f;
        [SerializeField] private InteractableBubble _bubble;
        
        private Interactor _currentInteractor;
        private float _interactionTimer;
    }
}