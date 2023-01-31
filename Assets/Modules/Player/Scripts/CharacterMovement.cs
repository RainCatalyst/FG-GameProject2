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
            _targetDirection = Vector3.Lerp(_targetDirection, _currentDirection, _smooth * Time.deltaTime);
            _rb.velocity = new Vector3(_targetDirection.x, 0, _targetDirection.y) * _speed;
            //
            // if (_targetDirection != Vector2.zero)
            // {
            //     var targetRotation = Quaternion.Euler(0, Mathf.Atan2(_targetDirection.y, _targetDirection.x) * Mathf.Rad2Deg, 0);
            //     transform.localRotation =
            //         Quaternion.Slerp(transform.localRotation, targetRotation, Time.deltaTime * _smooth);
            // }
        }
        
        [SerializeField] private float _speed = 4f;
        [SerializeField] private float _smooth = 24f;
        
        private Vector2 _targetDirection;
        private Vector2 _currentDirection;
        private bool _isMovementLocked;
        private Rigidbody _rb;
    }
}