using UnityEngine;

[CreateAssetMenu(fileName = "VoidEventChannel", menuName = "Data/EventChannels/VoidEventChannel")]
public class VoidEventChannel : ScriptableObject
{
    event System.Action Delegate;

    public void BroadCast()
    {
        Delegate?.Invoke();
    }

    public void AddListener(System.Action action)
    {
        Delegate += action;
    }

    public void RemoveListener(System.Action action)
    {
        Delegate -= action;
    }
}
