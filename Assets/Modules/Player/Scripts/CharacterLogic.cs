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
            
            _interactor.Setup(_itemHolder, _characterType);

            _interactor.InteractionStarted += OnInteractionStarted;
            _interactor.InteractionFinished += OnInteractionFinished;
            
            _input.SetPlayerIndex((int) _characterType);
        }

        private void Update()
        {
            // Movement
            Vector2 moveDirection = _input.GetAxis();
            _movement.Move(moveDirection);

            // Interactions
            if (_input.IsInteractionPressed())
            {
                if (_interactor.CanInteract)
                {
                    _interactor.Interact();
                }
                else if (_interactor.CanDropItem)
                {
                    _interactor.DropItem();
                }
            }

            if (_input.IsInteractionReleased())
            {
                _interactor.CancelInteract();
            }

            //Seth edit (added new button to throw)
            if (_input.IsInteractionHeld() && _interactor.CanDropItem)
            {
                _interactor._throwForce += Time.deltaTime * _chargeSpeed;
            }

            if (_input.IsChargeReleased() && _interactor.CanDropItem)
            {
                _interactor.DropItem();
                _interactor._throwForce = 5f;
            }
            
            // Animation
            _animator.SetFloat("Speed", _movement.CurrentSpeed);
            _animator.SetBool("Holding", _itemHolder.ItemId != null);
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

        [SerializeField] private float _chargeSpeed = 5f;

        private CharacterMovement _movement;
        private CharacterInput _input;
        private Interactor _interactor;
        private ItemHolder _itemHolder;
    }
}
