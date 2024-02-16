using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Movement2D : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float moveSpeed;
    [SerializeField] float maxSpeed;

    [FoldoutGroup("Events")]
    [SerializeField] UnityEvent onMoving;
    [FoldoutGroup("Events")]
    [SerializeField] UnityEvent onIdle;

    Vector2 input;

    private void FixedUpdate()
    {
        //rb.velocity = input * moveSpeed;     
        
        if(rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(input * moveSpeed);
        }
        
        if(rb.velocity.magnitude > 0)
        {
            onMoving.Invoke();
        }
        else
        {
            onIdle.Invoke();
        }
    }

    public void SetInput(Vector2 input)
    {
        this.input = Vector2.ClampMagnitude(input, 1);
    }

    public Vector2 GetDirectionalMovement()
    {
        return rb.velocity;
    }
}
