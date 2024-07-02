using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Event/CameraEventSO")]
public class CameraEventSO : ScriptableObject
{
    public UnityAction<int> OnEventRaised;
    public void RaiseEvent(int args)
    {
        OnEventRaised?.Invoke(args);
    }
}
