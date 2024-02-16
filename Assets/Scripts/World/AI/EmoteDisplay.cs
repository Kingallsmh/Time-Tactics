using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmoteDisplay : MonoBehaviour
{
    [FoldoutGroup("Emote")]
    [SerializeField] Animator emoteAnimator;
    [FoldoutGroup("Emote")]
    [SerializeField] string defaultAnimName = "Empty";

    [FoldoutGroup("Window")]
    [SerializeField] Animator windowAnimator;
    [FoldoutGroup("Window")]
    [SerializeField] string openPropertyName = "IsOpened";
    [FoldoutGroup("Window")]
    [SerializeField] string openState = "Opened";

    public void OpenWithEmote(string emoteAnim)
    {
        StopAllCoroutines();
        StartCoroutine(OpenEmoteWindowRoutine(emoteAnim));
    }

    public void CloseEmoteWindow()
    {
        StopAllCoroutines();
        PlayEmote(defaultAnimName);
        ToggleEmoteWindow(false);
    }

    IEnumerator OpenEmoteWindowRoutine(string emoteAnim)
    {
        ToggleEmoteWindow(true);
        while (!WindowIsPlayingState(openState))
        {
            yield return null;
        }
        PlayEmote(emoteAnim);
    }

    void ToggleEmoteWindow(bool isOpen)
    {
        windowAnimator.SetBool(openPropertyName, isOpen);
    }

    void PlayEmote(string emoteAnim)
    {
        emoteAnimator.Play(emoteAnim);
    }

    bool WindowIsPlayingState(string windowState)
    {
        return windowAnimator.GetCurrentAnimatorStateInfo(0).IsName(windowState);
    }
}
