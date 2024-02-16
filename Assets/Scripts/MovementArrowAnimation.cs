using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementArrowAnimation : MonoBehaviour
{
    [SerializeField] Transform arrowGraphic;
    [SerializeField] float totalFrames = 2;
    [SerializeField] float startFrame = 0;
    [SerializeField] float timePerFrame = 1;
    [SerializeField] float arrowFromCenterPosition = 0.5f;

    [FoldoutGroup("Debug")]
    [SerializeField] Vector3 startDirection;
    [FoldoutGroup("Debug")]
    [SerializeField] Vector3 endDirection;

    float currentFrame = 0;
    float currentTime = 0;

    private void Awake()
    {
        currentFrame = startFrame;
    }

    private void Update()
    {
        if(currentTime > timePerFrame)
        {
            currentTime = 0;
            currentFrame += 1;
            if(currentFrame > totalFrames)
            {
                currentFrame = 0;
            }
            SetArrow(currentFrame / totalFrames);
        }
        currentTime += Time.deltaTime;
    }

    public void SetWantedDirections(Vector3 startPosition, Vector3 endPosition)
    {
        startDirection = (startPosition - transform.position).normalized;
        endDirection = (transform.position - endPosition).normalized;
    }

    [Button]
    void SetArrow(float percent)
    {
        arrowGraphic.rotation = Quaternion.Slerp(Quaternion.LookRotation(startDirection), Quaternion.LookRotation(endDirection), percent);
        arrowGraphic.localPosition = Vector3.Lerp(startDirection * -arrowFromCenterPosition, endDirection * arrowFromCenterPosition, percent);            
    }
}
