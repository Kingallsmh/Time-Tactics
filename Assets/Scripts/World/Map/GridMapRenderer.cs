using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMapRenderer : MonoBehaviour
{
    [SerializeField] TileRenderer tilePrefab;
    [SerializeField] int renderDistance;
    [SerializeField] Vector2Int currentViewPoint = Vector2Int.zero;

    GameObject mapParent;
    ObjectPool<TileRenderer> tileRendPool;
    Dictionary<Vector2Int, TileRenderer> currentList;
    GridMapData mapData;

    public void Setup()
    {
        SetupParentObject();
        currentList = new Dictionary<Vector2Int, TileRenderer>();
        tileRendPool = new ObjectPool<TileRenderer>();
        tileRendPool.onPoolObjectRemoved += CheckPoolIsEmpty;
        tileRendPool.onPoolObjectRemoved += EnableTile;
        tileRendPool.onPoolObjectAdded += DisableTile;
        for(int i = 0; i < renderDistance*renderDistance*2; i++)
        {
            TileRenderer rend = Instantiate(tilePrefab, mapParent.transform);
            tileRendPool.AddPoolObject(rend);
        }
    }

    void CheckPoolIsEmpty(TileRenderer rend)
    {
        if(tileRendPool.GetPoolCount() == 0)
        {
            tileRendPool.AddPoolObject(Instantiate(tilePrefab, mapParent.transform));
        }
    }

    void DisableTile(TileRenderer rend)
    {
        rend.gameObject.SetActive(false);
    }

    void EnableTile(TileRenderer rend)
    {
        rend.gameObject.SetActive(true);
    }

    void SetupParentObject()
    {
        mapParent = new GameObject("Map");
        mapParent.transform.parent = transform;
        mapParent.transform.position = Vector3.zero;
    }

    public void LoadGridMapData(GridMapData data)
    {
        mapData = data;
    }

    public void RenderTiles()
    {
        for (int x = -renderDistance + currentViewPoint.x; x <= renderDistance + currentViewPoint.x; x++)
        {
            for (int y = -renderDistance + currentViewPoint.y; y <= renderDistance + currentViewPoint.y; y++)
            {
                Vector2Int coord = new Vector2Int(x, y);
                SetTile(coord, mapData.GetTileAtLocation(coord));
            }
        }
    }

    [Button]
    public void UpdateRender(Vector2Int newCoord)
    {
        Vector2Int xRange = new Vector2Int(Mathf.Min(newCoord.x, currentViewPoint.x), Mathf.Max(newCoord.x, currentViewPoint.x));
        Vector2Int yRange = new Vector2Int(Mathf.Min(newCoord.y, currentViewPoint.y), Mathf.Max(newCoord.y, currentViewPoint.y));

        for (int x = -renderDistance + xRange.x; x <= renderDistance + xRange.y; x++)
        {
            for (int y = -renderDistance + yRange.x; y <= renderDistance + yRange.y; y++)
            {
                Vector2Int coord = new Vector2Int(x, y);
                bool isNew = IsWithinRenderRange(coord, newCoord, renderDistance);
                bool isOld = IsWithinRenderRange(coord, currentViewPoint, renderDistance);

                if(isNew && isOld) { continue; }
                else if (isNew) { SetTile(coord, mapData.GetTileAtLocation(coord)); }
                else
                {
                    RemoveTile(coord);
                }
            }
        }
        currentViewPoint = newCoord;
    }    

    bool IsWithinRenderRange(Vector2Int value, Vector2Int viewerCoord, int range)
    {
        return (Mathf.Abs((value - viewerCoord).x) > range || Mathf.Abs((value - viewerCoord).y) > range) == false;        
    }

    void SetTile(Vector2Int coordinate, GridTile tile)
    {
        if(tile.tileType == 0) { return; }
        TileRenderer rend = tileRendPool.RemovePoolObject();
        rend.transform.position = ConvertCoordinateToWorldSpace(coordinate);
        currentList.Add(coordinate, rend);
    }

    void RemoveTile(Vector2Int coordinate)
    {
        if(currentList.TryGetValue(coordinate, out TileRenderer rend))
        {
            currentList.Remove(coordinate);
            tileRendPool.AddPoolObject(rend);
        }
    }

    Vector3 ConvertCoordinateToWorldSpace(Vector2Int coordinate)
    {
        return new Vector3(coordinate.x, 0, coordinate.y) * PixelUtilities.PIXELPERMETER;
    }
}
