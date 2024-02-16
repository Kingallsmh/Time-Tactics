using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelTransform : MonoBehaviour
{
    [SerializeField] Transform pTransform;
    [SerializeField] float pixelsPerUnit;

    [Button]
    public void SetLocalPositionByPixels(Vector3 pixels)
    {
        pTransform.localPosition = pixels * (1 / pixelsPerUnit);
    }

    [Button]
    public void MoveLocalPositionByPixels(Vector3 pixels)
    {
        pTransform.localPosition += pixels * (1 / pixelsPerUnit);
    }
}
