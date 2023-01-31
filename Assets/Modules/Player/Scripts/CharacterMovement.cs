using UnityEngine;

namespace SpaceGame
{
    public class CharacterMovement : MonoBehaviour
    {
        public void Move(Vector2 direction)
        {
            _targetDirection = direction;
        }

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            _targetDirection = Vector3.Lerp(_targetDirection, _currentDirection, _smooth * Time.deltaTime);
            _rb.velocity = new Vector3(_targetDirection.x, 0, _targetDirection.y) * _speed;
        }
        
        [SerializeField] private float _speed = 4f;
        [SerializeField] private float _smooth = 24f;
        
        private Vector2 _targetDirection;
        private Vector2 _currentDirection;
        private Rigidbody _rb;
    }
}