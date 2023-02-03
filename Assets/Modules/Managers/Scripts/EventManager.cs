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

            _repairEvents = GetComponent<RepairEventManager>();
            _repairEvents.Setup(this);
            _turretEvents = GetComponent<TurretEventManager>();
            _turretEvents.Setup(this);
        }

        public void AddEvent(BaseEvent baseEvent)
        {
            OnEventAdded(baseEvent);
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

        private RepairEventManager _repairEvents;
        private TurretEventManager _turretEvents;

        private List<BaseEvent> _activeEvents;
    }
}