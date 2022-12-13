using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
public class GameEvents : MonoSingleton<GameEvents>
{

    #region PoolEvents

    public delegate GameObject GetObjectsInPool(ObjectTypes objectTypes);
    public static event GetObjectsInPool OnGetObjectsInPool;
    public static GameObject GetObjectsInPoolMethod(ObjectTypes objectTypes)
    {
        return OnGetObjectsInPool?.Invoke(objectTypes);
    }

    #endregion

    #region GridEvents

    public delegate TileController GetTileInDictionaryWithCoordinates(Vector2 pos);
    public static event GetTileInDictionaryWithCoordinates OnGetTileInDictionaryWithCoordinates;
    public static TileController GetTileInDictionaryWithCoordinatesMethod(Vector2 pos)
    {
        return OnGetTileInDictionaryWithCoordinates?.Invoke(pos);
    }

    //**************************************************************//
    public delegate float GetTileWidthPosition();
    public static event GetTileWidthPosition OnGetTileWidthPosition;
    public static float? GetTileWidthPositionMethod()
    {
        return OnGetTileWidthPosition?.Invoke();
    }

    //**************************************************************//
    public delegate Dictionary<Vector2, TileController> GetDictionary();
    public static event GetDictionary OnGetDictionary;
    public static Dictionary<Vector2, TileController> GetDictionaryMethod()
    {
        return OnGetDictionary?.Invoke();
    }

    //**************************************************************//
    public delegate Vector2Int GetGridWidth();
    public static event GetGridWidth OnGetGridWidth;
    public static Vector2Int GetGridWidthMethod()
    {
        return (Vector2Int)OnGetGridWidth?.Invoke();
    }

    //**************************************************************//

    public delegate TileController GetTileInDictionaryWithPosition(Vector2 pos);
    public static event GetTileInDictionaryWithPosition OnGetTileInDictionaryWithPosition;
    public static TileController GetTileInDictionaryWithPositionMethod(Vector2 pos)
    {
        return OnGetTileInDictionaryWithPosition?.Invoke(pos);
    }

    #endregion


    #region LocatorEvents

    public delegate List<TileController> GetCurrentTiles(Vector3 startPosition, Vector2 size);
    public static event GetCurrentTiles OnGetCurrentTiles;
    public static List<TileController> GetCurrentTilesMethod(Vector3 startPosition, Vector2 size)
    {
        return OnGetCurrentTiles?.Invoke(startPosition, size);
    }

    //**************************************************************//

    public delegate void GetSoldier();
    public static event GetSoldier OnGetSoldier;
    public static void GetSoldierMethod()
    {
        OnGetSoldier?.Invoke();
    }

    #endregion


    #region InformationView Events

    public delegate void SetBuildingData(Sprite sprite, string name);
    public static event SetBuildingData OnSetBuildingData;
    public static void SetBuildingDataMethod(Sprite sprite, string name)
    {
        OnSetBuildingData?.Invoke(sprite, name);
    }

    //**************************************************************//
    public delegate void SetProductionData(Sprite sprite, string name);
    public static event SetProductionData OnSetProductionData;
    public static void SetProductionDataMethod(Sprite sprite, string name)
    {
        OnSetProductionData?.Invoke(sprite, name);
    }



    #endregion


    #region NeighborEvents

    public delegate void FindNeighbor(int width, int height, Dictionary<Vector2, TileController> tiles);
    public static event FindNeighbor OnFindNeighbor;
    public static void FindNeighborMethod(int width, int height, Dictionary<Vector2, TileController> tiles)
    {
        OnFindNeighbor?.Invoke(width, height, tiles);
    }

    //**************************************************************//

    public delegate TileController[] GetNeighbor(TileController tile);
    public static event GetNeighbor OnGetNeighbor;
    public static TileController[] GetNeighborMethod(TileController tile)
    {
        return OnGetNeighbor?.Invoke(tile);
    }

    #endregion


    #region PathFindingEvents

    public delegate Queue<TileController> GetPath(TileController start, TileController goal);
    public static event GetPath OnGetPath;
    public static Queue<TileController> GetPathMethod(TileController start, TileController goal)
    {
        return OnGetPath?.Invoke(start, goal);
    }

    public delegate TileController GetTileUnderMouse();
    public static event GetTileUnderMouse OnGetTileUnderMouse;
    public static TileController GetTileUnderMouseMethod()
    {
        return OnGetTileUnderMouse?.Invoke();
    }


    #endregion



}
