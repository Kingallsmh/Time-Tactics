using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageBox : MonoBehaviour
{
    [SerializeField] UnityEvent onDamagedBoxUsed;
    [SerializeField] UnityEvent<GameObject> onObjectDamaged;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Hitbox hitbox))
        {
            hitbox.DamageHitbox(gameObject);
            onDamagedBoxUsed.Invoke();
            onObjectDamaged.Invoke(hitbox.gameObject);
        }
    }
}
