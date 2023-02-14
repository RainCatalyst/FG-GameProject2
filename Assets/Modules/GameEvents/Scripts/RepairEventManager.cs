using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SpaceGame
{
    public class RepairEventManager : MonoBehaviour
    {
        public void Setup(EventManager manager)
        {
            _eventManager = manager;
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
            _eventManager.AddEvent(repairEvent);
        }
        
        private void Start()
        {
            _repairInteractables = FindObjectsOfType<RepairInteractable>();
            _repairEventTimer = _initialDelay;
        }
        
        private void Update()
        {
            // // Trigger repair events randomly
            // _repairEventTimer -= Time.deltaTime;
            // if (_repairEventTimer < 0)
            // {
            //     AddRepairEvent();
            //     _repairEventTimer = Random.Range(_delayMin, _delayMax);
            // }
        }
        
        [SerializeField] private float _initialDelay;
        [SerializeField] private float _delayMax;
        [SerializeField] private float _delayMin;
        
        private float _repairEventTimer;
        [SerializeField] private RepairInteractable[] _repairInteractables;
        private EventManager _eventManager;
    }
}