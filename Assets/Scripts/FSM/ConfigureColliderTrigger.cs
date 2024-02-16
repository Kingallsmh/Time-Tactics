using HutongGames.PlayMaker;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ActionCategory(ActionCategory.Physics)]
public class ConfigureColliderTrigger : FsmStateAction
{
    public FsmGameObject colliderObject;
    public FsmBool isTrigger;

    public override void OnEnter()
    {
        Collider collider = colliderObject.Value.GetComponent<Collider>();
        collider.isTrigger = isTrigger.Value;
        Finish();
    }
}
