using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteZPositionControl : MonoBehaviour
{
    [SerializeField] float rateOfZPos = 0.1f;

    private void FixedUpdate()
    {
        SetPosition();
    }

    [Button]
    public void SetPosition()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
    }
}
