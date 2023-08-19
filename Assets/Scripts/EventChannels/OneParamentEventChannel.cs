using UnityEngine;

public class OneParaMentEventChannel<T> : ScriptableObject
{
    event System.Action<T> Delegate;

    public void BroadCast(T obj)
    {
        Delegate?.Invoke(obj);
    }

    public void AddListener(System.Action<T> action)
    {
        Delegate += action;
    }

    public void RemoveListener(System.Action<T> action)
    {
        Delegate -= action;
    }
}
