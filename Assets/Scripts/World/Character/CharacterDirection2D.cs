using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterDirection2D : MonoBehaviour
{
    Vector2 lastDirection;
    [SerializeField] UnityEvent<Vector2> onLastDirection;

    public void SetCurrentDirection(Vector2 input)
    {
        if(input.magnitude > 0)
        {
            lastDirection = input;
            onLastDirection.Invoke(lastDirection);
        }
        
    }

    public Vector2 GetLastDirection()
    {
        return lastDirection;
    }
}
