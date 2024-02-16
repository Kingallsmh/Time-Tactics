using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterArrowFacing : MonoBehaviour
{
    [SerializeField] Transform arrowPivot;

    public void PointArrowByInput(Vector2 input)
    {
        float angle = Mathf.Atan2(input.y, input.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
