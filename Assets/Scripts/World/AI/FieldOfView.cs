using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] float viewRadius;
    [Range(0, 360)]
    [SerializeField] float viewAngle;
    [SerializeField] LayerMask targetMask;
    [SerializeField] LayerMask obstacleMask;
    [SerializeField] UnityEvent<List<GameObject>> onObjectsInVisionUpdated;

    List<GameObject> objectsInVision = new List<GameObject>();

    public float ViewRadius { get => viewRadius; set => viewRadius = value; }
    public float ViewAngle { get => viewAngle; set => viewAngle = value; }
    public List<GameObject> ObjectsInVision { get => objectsInVision; set => objectsInVision = value; }

    public void FindVisibleTargets()
    {
        objectsInVision.Clear();
        //Find all targets in the circle
        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, viewRadius, targetMask);
        for (int i = 0; i < targets.Length; i++)
        {
            Transform target = targets[i].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            //Check if targets are in the angle
            if (Vector3.Angle(transform.right, directionToTarget) < viewAngle / 2)
            {
                float distance = Vector3.Distance(transform.position, target.position);
                //Check for any obstacles that would obscure the target
                if (!Physics2D.Raycast(transform.position, directionToTarget, distance, obstacleMask))
                {
                    ObjectsInVision.Add(target.gameObject);
                }
            }
        }
        onObjectsInVisionUpdated.Invoke(objectsInVision);
    }

    public Vector3 DirectionFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        angleInDegrees += 90;
        if (!angleIsGlobal)
        {
            angleInDegrees += -transform.eulerAngles.z;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad), 0);
    }

    
}
