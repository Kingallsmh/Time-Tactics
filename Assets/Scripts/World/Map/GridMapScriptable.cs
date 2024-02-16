using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "World/GridMap")]
public class GridMapScriptable : SerializedScriptableObject
{
    [SerializeField]
    Dictionary<Vector2Int, GridTile> gridMap;

    public TileCoordinatePair[] GetArrayOfTiles()
    {
        TileCoordinatePair[] pairArray = new TileCoordinatePair[gridMap.Count];
        int i = 0;
        foreach (KeyValuePair<Vector2Int, GridTile> tile in gridMap)
        {
            pairArray[i] = new TileCoordinatePair();
            pairArray[i].tile = tile.Value;
            pairArray[i].x = tile.Key.x;
            pairArray[i].y = tile.Key.y;
            i++;
        }
        return pairArray;
    }

    public void LoadArrayOfTiles(TileCoordinatePair[] tileCoordArray)
    {
        for (int i = 0; i < tileCoordArray.Length; i++)
        {
            gridMap.Add(tileCoordArray[i].GetCoordinate(), tileCoordArray[i].tile);
        }
    }
}
