using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "BoolEventChannel", menuName = "Events/Bool Event Channel")]
public class BoolEventChannelSO : ScriptableObject
{
    public event UnityAction<bool> ValueUpdated;
    public void UpdateValue(bool value) => ValueUpdated?.Invoke(value);
}
