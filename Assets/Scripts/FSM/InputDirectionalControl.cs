using HutongGames.PlayMaker;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDirectionalControl : FsmStateAction
{
    public FsmGameObject inputObject;
    public FsmVector2 directionalInput;
    public FsmInt directionalIndex;
    public FsmBool resetOnExit;
    UnitInput input;

    public override void OnEnter()
    {
        input = inputObject.Value.GetComponent<UnitInput>();
    }

    public override void OnUpdate()
    {
        UseDirectional(directionalIndex.Value, directionalInput.Value);
    }

    public void UseDirectional(int layer, Vector2 value)
    {
        input.GiveValue(new InputValue(layer, value));
    }

    public override void OnExit()
    {
        if (resetOnExit.Value)
        {
            UseDirectional(directionalIndex.Value, Vector2.zero);
        }
    }
}
