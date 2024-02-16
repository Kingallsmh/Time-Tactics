using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonStateListener : MonoBehaviour
{
    [SerializeField] UnityEvent onButtonDown;
    [SerializeField] UnityEvent onButtonHeld;
    [SerializeField] UnityEvent onButtonUp;
    [SerializeField] UnityEvent<bool> onButton;

    public void SetButtonstateForListener(ButtonState state)
    {
        if(gameObject.activeInHierarchy == false) { return; }
        if (state.isDown) { onButtonDown.Invoke(); }
        if (state.isHeld) { onButtonHeld.Invoke(); }
        if (state.isUp) { onButtonUp.Invoke(); }
        onButton.Invoke(state.isHeld);
    }
}
