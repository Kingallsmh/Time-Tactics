using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class PlayerTouchInput : MonoBehaviour
{
    [SerializeField] UnityEvent<Vector2> onTouchInputUsed;

    public void GetPlayerTouchContext(InputAction.CallbackContext context)
    {
        //Debug.Log(context.valueType);
        //Debug.Log(context.ReadValueAsObject());
        object val = context.ReadValueAsObject();
        if(val != null)
        {
            TouchState state = (TouchState)val;
            onTouchInputUsed.Invoke(state.position);
        }
    }
}
