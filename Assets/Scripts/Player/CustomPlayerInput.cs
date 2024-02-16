using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomPlayerInput : MonoBehaviour
{
    [SerializeField] DirectionalInput[] directionalInputs;
    [SerializeField] ButtonInput[] btns;

    private void Update()
    {
        for(int i = 0; i < directionalInputs.Length; i++)
        {
            directionalInputs[i].UpdateInput();
        }
        for (int i = 0; i < btns.Length; i++)
        {
            btns[i].UpdateInput();
        }
    }

    public DirectionalInput[] GetDirectionalInputs()
    {
        return directionalInputs;
    }

    public ButtonInput[] GetButtonInputs()
    {
        return btns;
    }
}

[Serializable]
public class DirectionalInput
{
    public string directionalXName = "Horizontal";
    public string directionalYName = "Vertical";
    [FoldoutGroup("Events")]
    public UnityEvent<Vector2> onDirectionalInput = new UnityEvent<Vector2>();

    public void UpdateInput()
    {        
        onDirectionalInput.Invoke(new Vector2(Input.GetAxisRaw(directionalXName), Input.GetAxisRaw(directionalYName)));
    }
}

[Serializable]
public class ButtonInput
{
    public string inputName = "Btn1";
    [FoldoutGroup("Events")]
    public UnityEvent<ButtonState> onButtonInput = new UnityEvent<ButtonState>();

    public void UpdateInput()
    {
        onButtonInput.Invoke(new ButtonState(Input.GetButtonDown(inputName), Input.GetButton(inputName), Input.GetButtonUp(inputName)));
    }
}

public struct ButtonState
{
    public bool isDown;
    public bool isHeld;
    public bool isUp;

    public ButtonState(bool down, bool held, bool up)
    {
        isDown = down;
        isHeld = held;
        isUp = up;
    }
}