using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StatsHurtComponent : MonoBehaviour
{
    [SerializeField] CharacterStats stats;

    public void ReceiveDamage(string statType, int value)
    {
        Debug.Log("Taken :" + value + " " + statType);
        stats.AdjustResource(statType, -value);
    }
}
