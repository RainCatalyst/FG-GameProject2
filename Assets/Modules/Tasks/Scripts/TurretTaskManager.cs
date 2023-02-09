using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace SpaceGame
{
    public class TurretTaskManager : MonoBehaviour
    {
        public bool CanCompleteTask(string itemId) => _currentTask.Data.ItemId == itemId;
        
        public void CompleteTask()
        {
            // Update score etc
            _taskCompleteEvent.RaiseEvent();
            GetNewTask();
            print("Task competed! :>");
        }

        private void OnTaskFailed()
        {
            // Do something bad :<
            GetNewTask();
            print("Task failed! :<");
        }
        
        public void GetNewTask()
        {
            var taskData = _availableTasks[Random.Range(0, _availableTasks.Count)];
            _taskIcon.sprite = taskData.Icon;
            _currentTask = new Task(taskData);
        }
        
        private void Start()
        {
            GetNewTask();
        }

        private void Update()
        {
            if (_currentTask != null)
            {
                _currentTask.Update();
                float progress = _currentTask.GetProgress();
                // Update progress bar
                _taskProgressBar.Progress = progress;
                if (progress <= 0)
                {
                    OnTaskFailed();
                }
            }
        }

        [SerializeField]
        private List<TaskData> _availableTasks;
        [SerializeField]
        private ProgressBar _taskProgressBar;
        [SerializeField]
        private Image _taskIcon;
        [SerializeField]
        private VoidEventChannel _taskCompleteEvent;
        [SerializeField]
        private VoidEventChannel _turretFailedChannel;

        private Task _currentTask;
    }
}