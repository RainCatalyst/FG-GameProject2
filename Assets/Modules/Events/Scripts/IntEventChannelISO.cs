using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "IntEventChannel", menuName = "Events/Int Event Channel")]
public class IntEventChannelSO : ScriptableObject
{
    public event UnityAction<int> ValueUpdated;
    public void UpdateValue(int value) => ValueUpdated?.Invoke(value);
}
