using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileRenderer : MonoBehaviour
{
    [SerializeField] SpriteRenderer rend;

    public void SetSprite(Sprite sprite)
    {
        rend.sprite = sprite;
    }
}
