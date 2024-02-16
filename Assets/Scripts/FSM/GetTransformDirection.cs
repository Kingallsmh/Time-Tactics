using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HutongGames.PlayMaker;

[ActionCategory(ActionCategory.Transform)]
public class GetTransformDirection : FsmStateAction
{
    public FsmGameObject transformObject;
    public FsmVector3 directionToConvertFromTransform;
    public FsmVector3 directionOutput;

    public override void OnEnter()
    {
        directionOutput.Value = transformObject.Value.transform.TransformDirection(directionToConvertFromTransform.Value);
        Finish();
    }
}
