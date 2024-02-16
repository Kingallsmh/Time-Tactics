using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTarget : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float lerpAmount;

    Vector2 camVelocity;

    private void LateUpdate()
    {
        SetCameraPosition();
    }

    void SetCameraPosition()
    {
        if(target == null) { return; }
        transform.position = Vector2.SmoothDamp(transform.position, target.position, ref camVelocity, lerpAmount * Time.deltaTime);
    }
}
