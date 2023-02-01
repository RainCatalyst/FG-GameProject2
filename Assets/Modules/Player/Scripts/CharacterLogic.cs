using System;
using UnityEngine;

namespace SpaceGame
{
    public class CharacterLogic : MonoBehaviour
    {
        private void Awake()
        {
            _movement = GetComponent<CharacterMovement>();
            _input = GetComponent<CharacterInput>();
            _interactor = GetComponent<Interactor>();
            _itemHolder = GetComponent<ItemHolder>();

            _interactor.InteractionStarted += OnInteractionStarted;
            _interactor.InteractionFinished += OnInteractionFinished;
            
            _input.SetPlayerIndex((int) _characterType);
        }

        private void Start()
        {
            _itemHolder.SetItem("repairkit");
        }

        private void Update()
        {
            // Movement
            Vector2 moveDirection = _input.GetAxis();
            _movement.Move(moveDirection);

            // Interactions
            if (_input.IsInteractionPressed())
            {
                _interactor.TryInteract();
            }

            if (_input.IsInteractionReleased())
            {
                _interactor.CancelInteract();
            }
            
            // Animation
            _animator.SetFloat("Speed", _movement.CurrentSpeed);
            _animator.SetBool("Holding", false);
        }

        private void OnInteractionStarted()
        {
            _movement.SetMovementLock(true);
        }
        
        private void OnInteractionFinished()
        {
            _movement.SetMovementLock(false);
        }

        [SerializeField] private CharacterType _characterType;
        [SerializeField] private Animator _animator;

        private CharacterMovement _movement;
        private CharacterInput _input;
        private Interactor _interactor;
        private ItemHolder _itemHolder;
    }
}
