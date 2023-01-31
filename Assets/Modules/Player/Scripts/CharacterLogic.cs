using UnityEngine;

namespace SpaceGame
{
    public class CharacterLogic : MonoBehaviour
    {
        private void Awake()
        {
            _movement = GetComponent<CharacterMovement>();
            _input = GetComponent<CharacterInput>();
            
            _input.SetPlayerIndex((int) _characterType);
        }

        private void Update()
        {
            Vector2 moveDirection = _input.GetAxis();
            print(moveDirection);
            _movement.Move(moveDirection);
        }

        [SerializeField] private CharacterType _characterType;

        private CharacterMovement _movement;
        private CharacterInput _input;
    }
}
