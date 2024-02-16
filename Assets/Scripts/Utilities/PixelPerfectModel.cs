using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelPerfectModel : MonoBehaviour
{
    [SerializeField] float pixelsPerUnit;

    private void LateUpdate()
    {
        UpdatePixelLocation();
    }

    void UpdatePixelLocation()
    {
        transform.localPosition = Vector3.zero;
        float x = (Mathf.Round(transform.position.x * pixelsPerUnit)/ pixelsPerUnit);
        float y = (Mathf.Round(transform.position.y * pixelsPerUnit) / pixelsPerUnit);
        float z = (Mathf.Round(transform.position.z * pixelsPerUnit) / pixelsPerUnit);
        Vector3 pixelLocation = new Vector3(x, y, z);
        transform.position = pixelLocation;
    }
}
