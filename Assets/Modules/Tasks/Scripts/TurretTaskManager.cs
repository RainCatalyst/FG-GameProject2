using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
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
            StartTaskCooldown(false);
        }

        private void OnTaskFailed()
        {
            // Quick hack for now
            for (int i = 0; i < _currentTask.Data.WallCount; i++)
                RepairManager.Instance.BreakRandom();
            for (int i = 0; i < _currentTask.Data.FireCount; i++)
                FireSpawnManager.Instance.SpawnFirePrefab();
            _taskFailEvent.RaiseEvent();
            StartTaskCooldown(true);
        }

        private void StartTaskCooldown(bool failed)
        {
            _taskCooldownTimer = failed ? 1f : _currentTask.Data.Cooldown;
            _taskCooldownDuration = failed ? 1f : _currentTask.Data.Cooldown;
            _taskIcon.sprite = _reloadIcon;
            _recipeHint.SetRecipeSprite(null, _recipeIndex);
            // _taskIconParent.SetActive(false);
            // _taskProgressBar.ColorOverProgress = _taskCooldownGradient;
            _currentTask = null;
        }
        
        public void GetNewTask()
        {
            //Seth edit
            //var taskData = _availableTasks[Random.Range(0, _availableTasks.Count)];
            bool isRareTask = Random.value > _chance;
            var taskData = _availableTasks[isRareTask ? Random.Range(1, _availableTasks.Count) : 0];
            if (isRareTask)
            {
                _recipeHint.SetRecipeSprite(taskData.RecipeIcon, _recipeIndex);
            }

            _taskIcon.sprite = taskData.ResultIcon;
            // _taskIconParent.SetActive(true);
            // _taskProgressBar.ColorOverProgress = _taskWaitGradient;
            _currentTask = new Task(taskData);
        }
        
        private void Start()
        {
            GetNewTask();
        }

        private void Update()
        {
            if (GameManager.Instance.IsGameplayPaused)
                return;
            if (_currentTask != null)
            {
                _currentTask.Update();
                float progress = _currentTask.GetProgress();
                // Update progress bar
                _taskProgressBar.Progress = progress;
                _taskProgressBar.Color = _taskWaitGradient.Evaluate(_taskProgressBar.Progress);

                if (_currentTask.IsFailed)
                {
                    OnTaskFailed();
                }
            }
            else if (_taskCooldownTimer > 0f)
            {
                _taskCooldownTimer -= Time.deltaTime;
                _taskProgressBar.Progress = 1f - _taskCooldownTimer / _taskCooldownDuration;
                _taskProgressBar.Color = _taskCooldownGradient.Evaluate(_taskProgressBar.Progress);
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
        private Sprite _reloadIcon;
        [SerializeField]
        private RecipeHint _recipeHint;
        [SerializeField]
        private int _recipeIndex;
        [SerializeField]
        private VoidEventChannel _taskCompleteEvent;
        [SerializeField]
        private VoidEventChannel _taskFailEvent;

        private Task _currentTask;
        private float _taskCooldownTimer;
        private float _taskCooldownDuration;
        [SerializeField]
        private float _chance = 0.5f;
    }
}