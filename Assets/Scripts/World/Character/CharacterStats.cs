using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] StatsData data;

    public void AdjustResource(string name, int value)
    {
        data.AdjustResource(name, value);
    }

    public ResourceAttribute GetResource(string name)
    {
        return data.GetResourceByName(name);
    }

    public void AddEventOnResource(string name, Action<float> action)
    {
        ResourceAttribute stat = GetResource(name);
        if(stat != null)
        {
            stat.onValueUpdated.AddListener(action.Invoke);
        }        
    }

    public void RemoveEventOnResource(string name, Action<float> action)
    {
        ResourceAttribute stat = GetResource(name);
        if (stat != null)
        {
            stat.onValueUpdated.RemoveListener(action.Invoke);
        }
    }
}
