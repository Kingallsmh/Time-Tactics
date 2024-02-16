using HutongGames.PlayMaker;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseEmoteDisplay : FsmStateAction
{
    public FsmGameObject emoteDisplayObject;
    public FsmString emoteName;

    EmoteDisplay emoteDisplay;

    public override void OnEnter()
    {
        emoteDisplay = emoteDisplayObject.Value.GetComponent<EmoteDisplay>();
        emoteDisplay.OpenWithEmote(emoteName.Value);
        Finish();
    }
}
