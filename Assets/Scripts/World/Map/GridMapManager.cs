using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMapManager : MonoBehaviour
{
    [SerializeField]
    GridMapRenderer gridRender;

    GridMapData data;

    [Button]
    public void LoadMapFromScriptable(GridMapScriptable mapData)
    {
        data = new GridMapData();
        data.LoadArrayOfTiles(mapData.GetArrayOfTiles());
        gridRender.Setup();
        gridRender.LoadGridMapData(data);
        gridRender.RenderTiles();
    }
}
