using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SpriteFramer : MonoBehaviour
{
    [SerializeField] int currentFrame;
    int lastFrame;
    [SerializeField] SpriteRenderer render;
    [SerializeField] List<Sprite> spriteList;


    public void SetFrame(int value)
    {
        if(value < 0 || spriteList.Count < value)
        {
            Debug.LogError("Out of bounds : " + value);
            return;
        }
        render.sprite = spriteList[value];
    }

    private void LateUpdate()
    {
        if(lastFrame == currentFrame) { return; }
        lastFrame = currentFrame;
        SetFrame(currentFrame);
    }

    public void SetSpriteList(List<Sprite> sprites)
    {
        spriteList = sprites;
    }

    public void SetSpriteList(Sprite[] sprites)
    {
        spriteList.Clear();
        spriteList.AddRange(sprites);
    }
}
