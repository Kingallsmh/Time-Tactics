using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class StatAttribute
{
    public string statName;
    public float baseValue;
    [FoldoutGroup("Event")]
    public UnityEvent<float> onStatValueUpdated;

    public StatAttribute() { }
    public StatAttribute(string name, float value) 
    {
        statName = name;
        baseValue = value;
    }

    public void SetBaseValue(float value)
    {
        baseValue = value;
        onStatValueUpdated.Invoke(value);
    }

    public void AddBaseValue(float value)
    {
        SetBaseValue(baseValue + value);
    }

    public StatAttribute GetCopy()
    {
        return new StatAttribute(statName, baseValue);
    }
}

[Serializable]
public struct StatAdditionModifier
{
    public string name;
    public float value;

    public StatAdditionModifier(string statName, float value)
    {
        this.name = statName;
        this.value = value;
    }
}

[Serializable]
public struct StatMultiplierModifier
{
    public string name;
    public float value;

    public StatMultiplierModifier(string statName, float value)
    {
        this.name = statName;
        this.value = value;
    }
}
