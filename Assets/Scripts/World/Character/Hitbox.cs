using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hitbox : MonoBehaviour
{
    [SerializeField] UnityEvent onCharacterHit;
    [SerializeField] UnityEvent<GameObject> onHitByObject;

    public void DamageHitbox(GameObject damager)
    {
        onCharacterHit.Invoke();
        onHitByObject.Invoke(damager);
    }
}
