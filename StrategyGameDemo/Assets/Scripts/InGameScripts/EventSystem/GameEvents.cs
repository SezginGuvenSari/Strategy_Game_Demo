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



}
