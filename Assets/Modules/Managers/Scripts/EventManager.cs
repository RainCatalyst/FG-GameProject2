using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SpaceGame
{
    public class EventManager : MonoSingleton<EventManager>
    {
        protected override void Awake()
        {
            base.Awake();
            _activeEvents = new();

            _turretInteractables = FindObjectsOfType<TurretInteractable>();
            _repairInteractables = FindObjectsOfType<RepairInteractable>();
            
            AddTurretEvents();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                AddRepairEvent();
        }

        public void AddRepairEvent()
        {
            var availableRepairables = _repairInteractables.Where(r => r.IsRepaired).ToArray();
            if (availableRepairables.Length == 0)
            {
                Debug.LogWarning("Unable to add a RepairEvent, no more interactables to break!");
                return;
            }

            var repairEvent = new RepairEvent(availableRepairables[Random.Range(0, availableRepairables.Length)]);
            OnEventAdded(repairEvent);
        }

        private void AddTurretEvents()
        {
            foreach (var turret in _turretInteractables)
            {
                var turrentEvent = new TurretEvent(turret);
                OnEventAdded(turrentEvent);
            }
        }

        private void OnEventAdded(BaseEvent baseEvent)
        {
            _activeEvents.Add(baseEvent);
            baseEvent.Finished += OnEventFinished;
            baseEvent.Begin();
            print($"Added! Total events: {_activeEvents.Count}");
        }

        private void OnEventFinished(BaseEvent baseEvent, bool win)
        {
            baseEvent.End();
            _activeEvents.Remove(baseEvent);
            print($"Removed! Total events: {_activeEvents.Count}");
        }

        private RepairInteractable[] _repairInteractables;
        private TurretInteractable[] _turretInteractables;
        
        private List<BaseEvent> _activeEvents;
    }
}