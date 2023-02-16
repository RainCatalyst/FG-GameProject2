using UnityEngine;

namespace SpaceGame
{
    public class Task 
    {
        public TaskData Data => _data;
        public bool IsFailed => _isFailed;

        // Constructor that takes a TaskData object as an argument and assigns it to _data
        public Task(TaskData data) 
        {
            _data = data;
            _timer = data.TimeToDeliver;
        }

        // Gives us a progress value from 0 (just started) to 1 (task failed). Dividing time elapsed by duration of the task.
        public float GetProgress()
        {
            return _timer / _data.TimeToDeliver;
        }

        public void Update()
        {
            _timer -= Time.deltaTime;
            
            if (_timer <= 0f)
            {
                // If the timer hits zero when we were waiting for items, then we failed the task
                _isFailed = true;
            }
        }
        
        private TaskData _data;
        private float _timer;
        private bool _isFailed; // did the timer run out
    }
}