using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapHelper : MonoBehaviour
{
    [SerializeField] Tilemap map;

    [Button] 
    public void FillMap(Vector2Int startPoint, Vector2Int endPoint, Tile tileToUse)
    {
        for(int x = startPoint.x; x < endPoint.x; x++)
        {
            for (int y = startPoint.y; y < endPoint.y; y++)
            {
                map.SetTile(new Vector3Int(x, y, 0), tileToUse);
            }
        }
    }
}
