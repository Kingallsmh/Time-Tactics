using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T>
{
    List<T> pooledObjectList;
    public Action<T> onPoolObjectRemoved;
    public Action<T> onPoolObjectAdded;

    public ObjectPool()
    {
        SetupPool();
    }

    public void SetupPool()
    {
        pooledObjectList = new List<T>();
        onPoolObjectRemoved = delegate { };
        onPoolObjectAdded = delegate { };
    }

    public T RemovePoolObject()
    {
        T removeObject = pooledObjectList[0];
        pooledObjectList.RemoveAt(0);
        onPoolObjectRemoved.Invoke(removeObject);
        return removeObject;
    }

    public void AddPoolObject(T obj)
    {
        pooledObjectList.Add(obj);
        onPoolObjectAdded.Invoke(obj);
    }

    public int GetPoolCount()
    {
        return pooledObjectList.Count;
    }
}
