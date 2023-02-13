using System;
using UnityEngine;
using UnityEngine.Events;

namespace SpaceGame
{
    public class PlayerDetector : MonoBehaviour
    {
        public bool AreBothPlayersIn;
        
        private void OnTriggerEnter(Collider other)
        {
            print($"Someone entered! {other.name}");
            if (other.attachedRigidbody.GetComponent<CharacterLogic>() != null)
            {
                _playerCount++;
                print($"It's a player! Players: {_playerCount}");
                if (_playerCount == 2)
                {
                    AreBothPlayersIn = true;
                }
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            print($"Someone left! {other.name}");
            if (other.attachedRigidbody.GetComponent<CharacterLogic>() != null)
            {
                _playerCount--;
                print($"Player left! Players: {_playerCount}");
                if (_playerCount < 2)
                {
                    AreBothPlayersIn = false;
                }
            }
        }

        private int _playerCount = 0;
    }
}