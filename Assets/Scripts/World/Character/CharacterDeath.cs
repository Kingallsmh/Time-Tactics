using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterDeath : MonoBehaviour
{
    [SerializeField] GameObject characterObject;
    [SerializeField] GameObject deathPrefab;
    [FoldoutGroup("Event")]
    [SerializeField] UnityEvent onCharactertDeath;

    public void CheckCharactertDeath(float resourceValue)
    {
        if(resourceValue <= 0)
        {
            KillCharacter();
        }
    }

    public void KillCharacter()
    {
        GameObject obj = Instantiate(deathPrefab);
        obj.transform.position = transform.position;
        onCharactertDeath.Invoke();
        Destroy(characterObject);
    }
}
