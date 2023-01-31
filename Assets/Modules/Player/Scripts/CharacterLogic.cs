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

            _interactor.InteractionStarted += OnInteractionStarted;
            _interactor.InteractionFinished += OnInteractionFinished;
            
            _input.SetPlayerIndex((int) _characterType);
        }

        private void Update()
        {
            Vector2 moveDirection = _input.GetAxis();
            _movement.Move(moveDirection);

            if (_input.IsInteractionPressed())
            {
                _interactor.TryInteract();
            }

            if (_input.IsInteractionReleased())
            {
                _interactor.CancelInteract();
            }
        }

        private void OnInteractionStarted()
        {
            _movement.SetMovementLock(true);
            print("Started intraction!");
        }
        
        private void OnInteractionFinished()
        {
            _movement.SetMovementLock(false);
            print("Finished intraction!");
        }

        [SerializeField] private CharacterType _characterType;

        private CharacterMovement _movement;
        private CharacterInput _input;
        private Interactor _interactor;
    }
}
