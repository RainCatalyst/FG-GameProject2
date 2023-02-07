using UnityEngine;

namespace SpaceGame
{
    public class TurretEventManager : MonoBehaviour
    {
        public void Setup(EventManager manager)
        {
            _eventManager = manager;
        }

        private void AddTurretEvents()
        {
            foreach (var turret in _turretInteractables)
            {
                print(turret);
                var turrentEvent = new TurretEvent(turret);
                _eventManager.AddEvent(turrentEvent);
            }
        }
        
        private void Start()
        {
            _turretInteractables = FindObjectsOfType<TurretInteractable>();
            AddTurretEvents();
        }

        private TurretInteractable[] _turretInteractables;
        private EventManager _eventManager;
    }
}