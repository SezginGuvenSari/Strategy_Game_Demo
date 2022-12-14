using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoSingleton<ItemManager>
{
    #region Serialize

    [SerializeField]
    private bool _isSpawned = false;

    #endregion

    #region Properties

    public bool IsSpawned
    {
        get => _isSpawned;
        set => _isSpawned = value;
    }

    #endregion

}
