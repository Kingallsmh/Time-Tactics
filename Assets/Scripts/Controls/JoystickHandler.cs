using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class JoystickHandler : MonoBehaviour
{
    [SerializeField] Image knobImg;
    [SerializeField] Image areaImg;

    [SerializeField] float minDistanceFromCenter = 10;
    [SerializeField] float maxDistanceFromCenter = 100;

    [SerializeField] UnityEvent<Vector2> onTouchInput;

    public void SetTouchInput(Vector2 input)
    {
        Vector2 direction = transform.InverseTransformPoint(input);

        //If the input is too far away, don't bother with it
        if(direction.magnitude > maxDistanceFromCenter) { return; }
        if (direction.magnitude > minDistanceFromCenter)
        {
            ApplyInput(direction);
        }
        else
        {
            ApplyInput(Vector2.zero);
        }
    }

    void ApplyInput(Vector2 direction)
    {
        knobImg.transform.localPosition = direction;
    }
}
