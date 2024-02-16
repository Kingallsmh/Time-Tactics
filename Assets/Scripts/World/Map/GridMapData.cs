using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GridMapData
{
    public GridMapData()
    {
        gridMap = new Dictionary<Vector2Int, GridTile>();
    }

    public Dictionary<Vector2Int, GridTile> gridMap;

    public void AddTileToMap(GridTile tile, int xCoordinate, int yCoordinate)
    {
        AddTileToMap(tile, new Vector2Int(xCoordinate, yCoordinate));
    }

    public void AddTileToMap(GridTile tile, Vector2Int coordinate)
    {
        if (gridMap.ContainsKey(coordinate)) { Debug.LogWarning("already contains coordinate: " + coordinate); return; }
        gridMap.Add(coordinate, tile);
    }

    public bool IsTileAtLocation(int xCoordinate, int yCoordinate)
    {
        return gridMap.ContainsKey(new Vector2Int(xCoordinate, yCoordinate));
    }

    public bool IsTileAtLocation(Vector2Int coordinate)
    {
        return gridMap.ContainsKey(coordinate);
    }

    public void RemoveAtLocation(int xCoordinate, int yCoordinate)
    {
        RemoveAtLocation(new Vector2Int(xCoordinate, yCoordinate));
    }

    public void RemoveAtLocation(Vector2Int coordinate)
    {
        if (gridMap.ContainsKey(coordinate))
        {
            gridMap.Remove(coordinate);
        }
    }

    public GridTile GetTileAtLocation(int xCoordinate, int yCoordinate)
    {
        return GetTileAtLocation(new Vector2Int(xCoordinate, yCoordinate));
    }

    public GridTile GetTileAtLocation(Vector2Int coordinate)
    {
        if (gridMap.TryGetValue(coordinate, out GridTile tile))
        {
            return tile;
        }
        return new GridTile();
    }    

    public TileCoordinatePair[] GetArrayOfTiles()
    {
        TileCoordinatePair[] pairArray = new TileCoordinatePair[gridMap.Count];
        int i = 0;
        foreach(KeyValuePair<Vector2Int, GridTile> tile in gridMap)
        {
            pairArray[i].tile = tile.Value;
            pairArray[i].x = tile.Key.x;
            pairArray[i].y = tile.Key.y;
            i++;
        }
        return pairArray;
    }

    public void LoadArrayOfTiles(TileCoordinatePair[] tileCoordArray)
    {
        for(int i = 0; i < tileCoordArray.Length; i++)
        {
            gridMap.Add(tileCoordArray[i].GetCoordinate(), tileCoordArray[i].tile);
        }
    }
}

[Serializable]
public struct GridTile
{
    public int tileType;
}

[Serializable]
public class TileCoordinatePair
{
    public GridTile tile;
    public int x;
    public int y;

    public Vector2Int GetCoordinate()
    {
        return new Vector2Int(x, y);
    }
}
