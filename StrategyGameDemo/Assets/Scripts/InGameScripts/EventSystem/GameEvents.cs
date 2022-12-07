using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameEvents : MonoSingleton<GameEvents>
{

    #region PoolEvents

    public delegate void GetObjectsInPool(ObjectTypes objectTypes);
    public static event GetObjectsInPool OnGetObjectsInPool;
    public static void GetObjectsInPoolMethod(ObjectTypes objectTypes)
    {
        OnGetObjectsInPool?.Invoke(objectTypes);
    }

    #endregion


    #region GridEvents

    public delegate TileController GetTileInDictionary(Vector2 pos);
    public static event GetTileInDictionary OnGetTileInDictionary;
    public static TileController GetTileInDictionaryMethod(Vector2 pos)
    {
        return OnGetTileInDictionary?.Invoke(pos);
    }

    public delegate float GetTileWidthPosition();
    public static event GetTileWidthPosition OnGetTileWidthPosition;
    public static float? GetTileWidthPositionMethod()
    {
        return OnGetTileWidthPosition?.Invoke();
    }

    public delegate Dictionary<Vector2, TileController> GetDictionary();
    public static event GetDictionary OnGetDictionary;
    public static Dictionary<Vector2, TileController> GetDictionaryMethod()
    {
        return OnGetDictionary?.Invoke();
    }

    #endregion

    #region LocatorEvents

    public delegate List<TileController> GetCurrentTiles(Vector3 startPosition, Vector2 size);
    public static event GetCurrentTiles OnGetCurrentTiles;
    public static List<TileController> GetCurrentTilesMethod(Vector3 startPosition, Vector2 size)
    {
        return OnGetCurrentTiles?.Invoke(startPosition, size);
    }

    #endregion


}
