using UnityEngine;

namespace SpaceGame
{
    [CreateAssetMenu(fileName = "Task", menuName = "Data/TaskData")]
    public class TaskData : ScriptableObject
    {
        public float TimeToDeliver => _timeToDeliver;
        public float Cooldown => _cooldown;
        public string ItemId => _itemId;
        public Sprite Icon => _icon;
        
        [SerializeField]
        private float _timeToDeliver;
        [SerializeField]
        private float _cooldown;
        [SerializeField]
        private string _itemId;
        [SerializeField]
        private Sprite _icon;
    }
}