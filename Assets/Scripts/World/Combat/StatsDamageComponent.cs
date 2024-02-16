using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsDamageComponent : MonoBehaviour
{
    [SerializeField] string statType;
    [SerializeField] int damageValue;

    public void TryDamageObject(GameObject obj)
    {
        if(obj.TryGetComponent(out StatsHurtComponent statHurt))
        {
            statHurt.ReceiveDamage(statType, damageValue);
        }
    }
}
