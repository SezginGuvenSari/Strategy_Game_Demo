using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameEvents : MonoSingleton<GameEvents>
{

    #region PoolEvents

    public delegate void GetObjectsInPool(ObjectTypes objectTypes);
    public static  event GetObjectsInPool OnGetObjectsInPool;
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
      return  OnGetTileInDictionary?.Invoke(pos);
    }


    public delegate float GetTileWidthPosition();
    public static event GetTileWidthPosition OnGetTileWidthPosition;
    public  static float? GetTileWidthPositionMethod()
    {
        return OnGetTileWidthPosition?.Invoke();
    }

    #endregion



}
