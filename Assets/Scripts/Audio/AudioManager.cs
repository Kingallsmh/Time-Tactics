using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] int startingSources;
    [SerializeField] int maxSources;

    ObjectPool<AudioSource> sourcePool;
    List<AudioSource> sourcesTrackList;

    private void Awake()
    {
        instance = this;

        SetupAudioSource(startingSources);
    }

    void SetupAudioSource(int startNumber)
    {
        sourcePool = new ObjectPool<AudioSource>();
        sourcesTrackList = new List<AudioSource>();
        for (int i = 0; i < startNumber; i++)
        {
            CreateAudioSourceObject();
        }
        sourcePool.onPoolObjectRemoved += OnPoolCheck;
    }

    void OnPoolCheck(AudioSource latestSource)
    {
        if(sourcePool.GetPoolCount() == 0)
        {
            if(sourcePool.GetPoolCount() <= maxSources)
            {
                CreateAudioSourceObject();
            }
        }
    }

    AudioSource CreateAudioSourceObject()
    {
        GameObject obj = new GameObject("Audio " + sourcePool.GetPoolCount());
        obj.transform.SetParent(transform);
        AudioSource audioObject = obj.AddComponent<AudioSource>();
        sourcePool.AddPoolObject(audioObject);
        sourcesTrackList.Add(audioObject);
        return audioObject;
    }

    public AudioSource FindSource()
    {
        AudioSource source = sourcePool.RemovePoolObject();
        return source;
    }

    public void ReturnSource(AudioSource source)
    {
        sourcePool.AddPoolObject(source);
    }
}
