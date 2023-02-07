using UnityEngine;
using UnityEngine.Events;

    [CreateAssetMenu(fileName = "NewVoidEventChannel", menuName = "Events/Void Event Channel")]
    public class VoidEventChannelSO : ScriptableObject
    {
        public event UnityAction OnEventRaised;

        public void RaiseEvent() => OnEventRaised?.Invoke();
    }
