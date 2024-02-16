using HutongGames.PlayMaker;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ActionCategory(ActionCategory.Transform)]
public class GetDirectionToObject : FsmStateAction
{
    public FsmGameObject fromGameObject;
    public FsmGameObject toGameObject;
    public FsmVector2 outputDirection;

    public FsmBool everyFrame;

    public override void OnEnter()
    {
        GetDirection();
        if(everyFrame.Value == false)
        {
            Finish();
        }        
    }

    public override void OnUpdate()
    {
        if (everyFrame.Value == true)
        {
            GetDirection();
        }
    }

    void GetDirection()
    {
        if (toGameObject.Value == null || fromGameObject.Value == null) { return; }
        outputDirection.Value = toGameObject.Value.transform.position - fromGameObject.Value.transform.position;
    }
}
