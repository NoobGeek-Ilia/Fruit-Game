using System.Collections.Generic;
using UnityEngine;

public class GridInfo
{
    public float GetGridMin_x { get => GetTilePos(0).x; }
    public float GetGridMax_x { get => GetTilePos(_tileContainer.Count - 1).x; }
    public float GetGridMin_z { get => GetTilePos(0).z; }
    public float GetGridMax_z { get => GetTilePos(_tileContainer.Count - 1).z; }

    private readonly GameObject _tile;
    private readonly int _width;
    private readonly int _height;

    private List<GameObject> _tileContainer = new List<GameObject>();
    public int GetTileNum { get => _tileContainer.Count; }
    public int GetGridWidth { get => _width; }
    public int GetGridHeight { get => _height; }
    public Vector3 GetTileScale { get => _tile.transform.localScale; }
    public GridInfo(int width, int height, GameObject tile)
    {
        _width = width;
        _height = height;
        _tile = tile;
    }
    public void FillTileContainer(GameObject tile) => _tileContainer.Add(tile);
    public Vector3 GetTilePos(int index) => _tileContainer[index].transform.position;
}