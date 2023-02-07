using UnityEngine;

namespace SpaceGame
{
    [CreateAssetMenu(fileName = "Task", menuName = "Data/TaskData")]
    public class TaskData : ScriptableObject
    {
        public float Duration => _duration;
        public string ItemId => _itemId;
        public Sprite Icon => _icon;
        
        [SerializeField]
        private float _duration;
        [SerializeField]
        private string _itemId;
        [SerializeField]
        private Sprite _icon;
    }
}