using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace SpaceGame
{
    public class TurretTaskManager : MonoBehaviour
    {
        // Returns true if current tasks itemid matches the input
        public bool CanDeliverTaskItem(string itemId) => _currentTask != null && _currentTask.Data.ItemId == itemId; 
        
        public void DeliverTaskItem()
        {
            OnTaskCompleted();
        }
        
        private void OnTaskCompleted()
        {
            // Update score etc
            _taskCompleteEvent.RaiseEvent();
            StartTaskCooldown();
            print("Task completed! :>");
        }

        private void OnTaskFailed()
        {
            _taskFailEvent.RaiseEvent();
            StartTaskCooldown();
            print("Task failed! :<");
        }

        private void StartTaskCooldown()
        {
            _taskCooldownTimer = _currentTask.Data.Cooldown;
            _taskCooldownDuration = _currentTask.Data.Cooldown;
            _taskIconParent.SetActive(false);
            _taskProgressBar.ColorOverProgress = _taskCooldownGradient;
            _currentTask = null;
        }
        
        public void GetNewTask()
        {
            var taskData = _availableTasks[Random.Range(0, _availableTasks.Count)];
            _taskIcon.sprite = taskData.Icon;
            _taskIconParent.SetActive(true);
            _taskProgressBar.ColorOverProgress = _taskWaitGradient;
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

                if (_currentTask.IsFailed)
                {
                    OnTaskFailed();
                }
            }
            else if (_taskCooldownTimer > 0f)
            {
                _taskCooldownTimer -= Time.deltaTime;
                _taskProgressBar.Progress = 1f - _taskCooldownTimer / _taskCooldownDuration;
                if (_taskCooldownTimer <= 0f)
                {
                    GetNewTask();
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
        private GameObject _taskIconParent;
        [SerializeField]
        private Gradient _taskWaitGradient;
        [SerializeField]
        private Gradient _taskCooldownGradient;
        [SerializeField]
        private VoidEventChannel _taskCompleteEvent;
        [SerializeField]
        private VoidEventChannel _taskFailEvent;

        private Task _currentTask;
        private float _taskCooldownTimer;
        private float _taskCooldownDuration;
    }
}