using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierData : BuildingData
{
    #region Serialize

    [SerializeField]
    private TileController _startTile;

    [SerializeField]
    private TileController _endTile;

    [SerializeField] [Range(1, 20)] private float _soldierSpeed;

    #endregion


    #region Properties

    public TileController StartTile
    {
        get => _startTile;
        set => _startTile = value;
    }

    public TileController EndTile
    {
        get => _endTile;
        set => _endTile = value;
    }

    public float SoldierSpeed
    {
        get => _soldierSpeed;
        set => _soldierSpeed = value;
    }


    #endregion


}
