using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class ResourceAttribute
{
    public string statName;
    public StatAttribute baseAttribute;
    public float value;
    [FoldoutGroup("Event")]
    public UnityEvent<float> onValueUpdated;
    [FoldoutGroup("Event")]
    public UnityEvent<float> onValueAdjustAmount;

    public ResourceAttribute() { }
    public ResourceAttribute(StatAttribute stat)
    {
        statName = stat.statName;
        baseAttribute = stat;
        value = stat.baseValue;
    }
    public ResourceAttribute(StatAttribute stat, float currentValue)
    {
        statName = stat.statName;
        baseAttribute = stat;
        value = currentValue;
    }

    public void AddResourceValue(float value)
    {
        SetResourceValue(value + this.value);
        onValueAdjustAmount.Invoke(value);
    }

    public void SetResourceValue(float value)
    {
        this.value = value;
        CheckStatMax();
        onValueUpdated.Invoke(this.value);
    }

    public float CheckStatMax()
    {
        return Mathf.Clamp(value, 0, baseAttribute.baseValue);
    }

    public ResourceAttribute GetCopy()
    {
        return new ResourceAttribute(baseAttribute, value);
    }
}
