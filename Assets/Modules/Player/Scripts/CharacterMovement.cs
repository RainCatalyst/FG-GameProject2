using UnityEngine;

namespace SpaceGame
{
    public class CharacterMovement : MonoBehaviour
    {
        public void SetMovementLock(bool locked)
        {
            _isMovementLocked = locked;
            if (locked)
                _targetDirection = Vector2.zero;
        }
        
        public void Move(Vector2 direction)
        {
            if (_isMovementLocked)
                return;
            _targetDirection = direction;
        }

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            // Handle movement
            _currentDirection = Vector3.Lerp(_currentDirection, _targetDirection, _smooth * Time.deltaTime);
            _rb.velocity = new Vector3(_currentDirection.x, 0, _currentDirection.y) * _speed;
            
            // Handle rotation
            if (_targetDirection != Vector2.zero)
            {
                var targetRotation = Quaternion.LookRotation(new Vector3(_targetDirection.x, 0, _targetDirection.y));
                transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * _rotationSmooth);
            }
        }
        
        [SerializeField] private float _speed = 4f;
        [SerializeField] private float _smooth = 24f;
        [SerializeField] private float _rotationSmooth = 16f;
        
        private Vector2 _targetDirection;
        private Vector2 _currentDirection;
        private bool _isMovementLocked;
        private Rigidbody _rb;
    }
}