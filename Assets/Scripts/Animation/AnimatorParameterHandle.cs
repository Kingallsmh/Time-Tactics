using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorParameterHandle : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] string parameterName;

    public void SetFloat(float paramValue)
    {
        animator.SetFloat(parameterName, paramValue);
    }

    public void SetBool(bool paramValue)
    {
        animator.SetBool(parameterName, paramValue);
    }

    public void SetTrigger()
    {
        animator.SetTrigger(parameterName);
    }
}
