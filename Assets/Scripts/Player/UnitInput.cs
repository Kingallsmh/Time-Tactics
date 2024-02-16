using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnitInput : MonoBehaviour
{
    [SerializeField]
    [FoldoutGroup("Events")]
    public List<UnityEvent<ButtonState>> buttonEvent;
    [SerializeField]
    [FoldoutGroup("Events")]
    public List<UnityEvent<Vector2>> vector2InputEvent;

    public void GiveValue(InputValue value)
    {
        if (value.value == null)
        {
            return;
        }
        
        if (value.value.GetType() == typeof(ButtonState))
        {
            if (value.inputLayer >= buttonEvent.Count) { return; }
            buttonEvent[value.inputLayer].Invoke((ButtonState)value.value);
            return;
        }

        if (value.value.GetType() == typeof(Vector2))
        {
            if (value.inputLayer >= vector2InputEvent.Count) { return; }
            vector2InputEvent[value.inputLayer].Invoke((Vector2)value.value);
            return;
        }
        
    }
}

[Serializable]
public struct InputValue
{
    public int inputLayer;
    public object value;

    public InputValue(int index, object value)
    {
        inputLayer = index;
        this.value = value;
    }

    public bool IsEqual(InputValue input)
    {
        if(input.inputLayer != inputLayer) { return false; }
        if(input.value != value) { return false; }
        return true;
    }
}
