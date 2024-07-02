using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName ="Event/PowerEventSO")]
public class PowerEventSO : ScriptableObject
{
    public UnityAction<Vector2> OnEventRaised;
    public void RaiseEvent(Vector2 args)
    {
        OnEventRaised?.Invoke(args);
    }
}
