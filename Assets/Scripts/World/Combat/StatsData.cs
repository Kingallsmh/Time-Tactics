using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class StatsData
{
    public List<StatAttribute> attributeList;
    public List<ResourceAttribute> resourceList;
    public List<StatAdditionModifier> additionList;
    public List<StatMultiplierModifier> multiplyList;
    [FoldoutGroup("Event")]
    public UnityEvent onStatsChanged;

    public StatAttribute GetAttributeByName(string name)
    {
        for(int i = 0; i < attributeList.Count; i++)
        {
            if(attributeList[i].statName.ToUpper() == name.ToUpper())
            {
                return attributeList[i];
            }
        }
        return null;
    }

    public ResourceAttribute GetResourceByName(string name)
    {
        for (int i = 0; i < resourceList.Count; i++)
        {
            if (resourceList[i].statName.ToUpper() == name.ToUpper())
            {
                return resourceList[i];
            }
        }
        return null;
    }

    public void AdjustResource(string name, int value)
    {
        ResourceAttribute resource = GetResourceByName(name);
        if (resource != null)
        {
            resource.AddResourceValue(value);
            onStatsChanged.Invoke();
        }
    }

    public void AddModifier(StatAdditionModifier mod)
    {
        additionList.Add(mod);
        onStatsChanged.Invoke();
    }

    public void AddModifier(StatMultiplierModifier mod)
    {
        multiplyList.Add(mod);
        onStatsChanged.Invoke();
    }

    public void RemoveModifier(StatAdditionModifier mod)
    {
        additionList.Remove(mod);
        onStatsChanged.Invoke();
    }

    public void RemoveModifier(StatMultiplierModifier mod)
    {
        multiplyList.Remove(mod);
        onStatsChanged.Invoke();
    }

    public float GetFullValueFromAttribute(string name)
    {
        StatAttribute attribute = GetAttributeByName(name);
        if (attribute != null)
        {
            float value = attribute.baseValue;
            //Add addition boosts first
            for(int i = 0; i < additionList.Count; i++)
            {
                if(additionList[i].name == name)
                {
                    value += additionList[i].value;
                }
            }
            //Add multiplicative boosts next
            for (int i = 0; i < multiplyList.Count; i++)
            {
                float multiplyValue = 0;
                if (multiplyList[i].name == name)
                {
                    multiplyValue += multiplyList[i].value;
                }
                value *= Mathf.Clamp(1 + multiplyValue, 0, float.PositiveInfinity);
            }
            return value;
        }
        return 0;
    }

    public StatsData GetCopy()
    {
        StatsData data = new StatsData();
        for(int i = 0; i < attributeList.Count; i++)
        {
            data.attributeList.Add(attributeList[i].GetCopy());
        }
        for (int i = 0; i < resourceList.Count; i++)
        {
            data.resourceList.Add(resourceList[i].GetCopy());
        }
        for (int i = 0; i < additionList.Count; i++)
        {
            data.additionList.Add(additionList[i]);
        }
        for (int i = 0; i < multiplyList.Count; i++)
        {
            data.multiplyList.Add(multiplyList[i]);
        }
        return data;
    }
}
