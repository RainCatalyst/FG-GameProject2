using UnityEngine;

namespace SpaceGame
{
    public class TurretTaskManager : MonoBehaviour
    {
        // active task
        // list of possible taskdata

        public void CompleteCurrentTask()
        {
            _taskCompleteEvent.RaiseEvent();
        }

        [SerializeField]
        private VoidEventChannel _taskCompleteEvent;
    }
}