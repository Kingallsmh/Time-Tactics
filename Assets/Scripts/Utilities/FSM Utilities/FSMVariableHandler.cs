using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMVariableHandler : MonoBehaviour
{
    [SerializeField] PlayMakerFSM fsm;
    [SerializeField] string variableName;

    public void SetGameObject(GameObject obj)
    {
        fsm.FsmVariables.GetFsmGameObject(variableName).Value = obj;
    }
}
