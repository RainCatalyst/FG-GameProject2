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
            _particles.PlayParticle();
        }
        
        private void OnTaskCompleted()
        {
            // Update score etc
            _taskCompleteEvent.RaiseEvent();
            GameManager.Instance.AddScore(_currentTask.Data.ScoreReward, transform.position + Vector3.up * 1.5f);
            StartTaskCooldown(false);
        }

        private void OnTaskFailed()
        {
            // Quick hack for now
            for (int i = 0; i < _currentTask.Data.WallCount; i++)
                RepairManager.Instance.BreakRandom();
            for (int i = 0; i < _currentTask.Data.FireCount; i++)
                FireSpawnManager.Instance.SpawnFire();
            _taskFailEvent.RaiseEvent();
            StartTaskCooldown(true);
            _particles.StopParticle();
        }

        private void StartTaskCooldown(bool failed)
        {
            _particles.PlayParticle();
            float multiplier = EncounterManager.CurrentEncounter.CooldownMultiplier;
            _taskCooldownTimer = failed ? 1f : _currentTask.Data.Cooldown * multiplier;
            _taskCooldownDuration = failed ? 1f : _currentTask.Data.Cooldown * multiplier;
            _taskIcon.sprite = _reloadIcon;
            _recipeHint.SetRecipe(null, _recipeIndex);
            
            _iconParent.SetActive(false);
            // _taskIconParent.SetActive(false);
            // _taskProgressBar.ColorOverProgress = _taskCooldownGradient;
            _currentTask = null;
        }
        
        public void GetNewTask()
        {
            //Seth edit
            //var taskData = _availableTasks[Random.Range(0, _availableTasks.Count)];
            var availableTasks = EncounterManager.CurrentEncounter.AvailableTasks;
            var taskData = availableTasks[Random.Range(0, availableTasks.Count)];
            bool isRareTask = ItemDatabase.Get(taskData.ItemId).IsSpecialAmmo;
            if (isRareTask)
            {
                _recipeHint.SetRecipe(taskData, _recipeIndex);
            }

            _iconParent.SetActive(true);
            _iconImage.sprite = taskData.ResultIcon;
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
                    _particles.StopParticle();
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
        [SerializeField] private Image _iconImage;
        [SerializeField] private GameObject _iconParent;
        [SerializeField] private LaserShoot _particles;

        private Task _currentTask;
        private float _taskCooldownTimer;
        private float _taskCooldownDuration;
        [SerializeField]
        private float _chance = 0.5f;
    }
}