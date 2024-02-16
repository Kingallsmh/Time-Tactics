using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HurtInvincibility : MonoBehaviour
{
    [SerializeField] float invincibleTime;

    [SerializeField] UnityEvent onInvincibilityOn;
    [SerializeField] UnityEvent onInvincibilityOff;

    bool isInvincible = false;

    public void StartInvincibility(float damage)
    {
        if (isInvincible || damage <= 0) { return; }
        StartCoroutine(TimerRoutine(invincibleTime));
    }

    IEnumerator TimerRoutine(float time)
    {
        isInvincible = true;
        onInvincibilityOn.Invoke();
        yield return new WaitForSeconds(time);
        onInvincibilityOff.Invoke();
        isInvincible = false;
    }
}
