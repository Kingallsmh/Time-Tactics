using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpriteFacing : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteModel;

    public void SetFacingFromInput(Vector2 input)
    {
        if(input.x == 0) { return; }
        if(input.x < 0) { spriteModel.flipX = true; }
        if(input.x > 0) { spriteModel.flipX = false; }
    }
}
