using UnityEngine;

namespace SpaceGame
{
    public class Task 
    {
        public TaskData Data => _data; 

        // Constructor that takes a TaskData object as an argument and assigns it to _data
        public Task(TaskData data) 
        {
            _data = data;
        }

        // Gives us a progress value from 0 (just started) to 1 (task failed). Dividing time elapsed by duration of the task.
        public float GetProgress()
        {
            return 1f - _timer / _data.Duration;
        }

        public void Update()
        {
            _timer += Time.deltaTime;
        }
        
        private TaskData _data;
        private float _timer;
    }
}