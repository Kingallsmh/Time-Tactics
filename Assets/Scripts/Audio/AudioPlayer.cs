using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    List<AudioSource> audioList = new List<AudioSource>();

    public void PlaySingleClip(AudioClip clip)
    {
        AudioSource audioInstance = GetAudioSource();
        if(audioInstance == null) { return; }
        audioInstance.clip = clip;
        audioInstance.Play();
        audioList.Add(audioInstance);
    }

    public void PlayRepeatedClip(AudioClip clip)
    {

    }

    public void StopRepeatedClip(AudioClip clip)
    {

    }

    AudioSource GetSourceWithClip(AudioClip clip)
    {
        for(int i = 0; i < audioList.Count; i++)
        {
            if(audioList[i].clip == clip)
            {
                return audioList[i];
            }
        }
        return null;
    }

    AudioSource GetAudioSource()
    {
        for(int i = 0; i < audioList.Count; i++)
        {
            if (audioList[i].isPlaying == false)
            {
                ReturnSource(audioList[i]);
            }
        }
        return AudioManager.instance.FindSource();
    }

    public void ReturnSource(AudioSource source)
    {
        AudioManager.instance.ReturnSource(source);
    }
}

