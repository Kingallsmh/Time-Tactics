using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraInput : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] UnityEvent<Vector2> onInputCoordinate;

    public void UpdateInputToWorld(Vector2 input)
    {
        onInputCoordinate.Invoke(cam.ScreenToWorldPoint(input));
    }
}
