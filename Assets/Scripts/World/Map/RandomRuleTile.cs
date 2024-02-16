using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "2D/Custom Tiles/Random Tile")]
public class RandomRuleTile : RuleTile
{
    public List<Sprite> possibleSprites;
}
