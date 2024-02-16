using HutongGames.PlayMaker;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseEmoteDisplay : FsmStateAction
{
    public FsmGameObject emoteDisplayObject;

    EmoteDisplay emoteDisplay;

    public override void OnEnter()
    {
        emoteDisplay = emoteDisplayObject.Value.GetComponent<EmoteDisplay>();
        emoteDisplay.CloseEmoteWindow();
        Finish();
    }
}
