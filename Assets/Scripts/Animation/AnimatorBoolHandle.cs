using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorBoolHandle : MonoBehaviour
{
    [SerializeField] Animator animator;

    public void SetBoolTrue(string name)
    {
        animator.SetBool(name, true);
    }

    public void SetBoolFalse(string name)
    {
        animator.SetBool(name, false);
    }

    public void SetBoolInvert(string name)
    {
        bool currentBool = animator.GetBool(name);
        animator.SetBool(name, !currentBool);
    }
}
