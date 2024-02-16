using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerUnitInput : MonoBehaviour
{
    [SerializeField] UnitInput unit;
    [SerializeField] CustomPlayerInput input;

    private void Awake()
    {
        DirectionalInput[] directions = input.GetDirectionalInputs();
        ButtonInput[] btns = input.GetButtonInputs();
        SetupDirections(directions);
        SetupButtons(btns);
    }

    void SetupDirections(DirectionalInput[] directions)
    {
        for(int i = 0; i < directions.Length; i++)
        {
            int index = new int();
            index = i;
            directions[i].onDirectionalInput.AddListener((value) => { UseDirectional(index, value); });
        }
    }

    void SetupButtons(ButtonInput[] btns)
    {
        for (int i = 0; i < btns.Length; i++)
        {
            int index = new int();
            index = i;
            btns[i].onButtonInput.AddListener((value) => { UseButton(index, value); });
        }
    }

    public void UseButton(int layer, ButtonState state)
    {
        if (unit == null) { return; }
        unit.GiveValue(new InputValue(layer, state));
    }

    public void UseDirectional(int layer,Vector2 value)
    {
        if(unit == null) { return; }
        unit.GiveValue(new InputValue(layer, value));
    }

    public void SwitchUnitInput(UnitInput input)
    {
        unit = input;
    }
}
