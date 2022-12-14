using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BarrackController : BuildingLocator, IInteractable, ISpawner
{

    #region References

    private BarrackData _barrackData;

    #endregion

    #region Serialize


    #endregion

    #region Properties
    public BarrackData BarrackData
    {
        get => _barrackData;
        set => _barrackData = value;
    }

    #endregion

    private void Awake() => _barrackData = GetComponent<BarrackData>();

    void Start() => base.Initialize();


    void Update() => base.PlacementProcess(_barrackData.StartPosition, _barrackData);

    public void Interact()
    {
        if (!_barrackData.IsBuild) return;
        GameEvents.SetBuildingDataMethod(_barrackData.ItemImage, _barrackData.ItemName);
        GameEvents.SetProductionDataMethod(_barrackData.ProductionImage, _barrackData.ProductionName);
    }

    private void GetSoldier()
    {
        var soldier = GameEvents.GetObjectsInPoolMethod(ObjectTypes.Soldier);
        if (soldier == null) return;
        var soldierData = soldier.GetComponent<SoldierData>();
        soldierData.IsBuild = true;
        FindSuitableLocation(soldier.transform);
    }

    private void FindSuitableLocation(Transform soldier)
    {
        while (true)
        {
            var grid = GameEvents.GetGridWidthMethod();
            var posX = Random.Range(0, grid.x);
            var posY = Random.Range(0, grid.y);
            var tile = GameEvents.GetTileInDictionaryWithCoordinatesMethod(new Vector2(posX, posY));

            if (tile.TileData.TileType != TileTypes.Walkable) continue;

            tile.TileData.TileType = TileTypes.UnWalkable;
            soldier.position = tile.transform.position;
            break;
        }
    }

    public void Spawner()
    {
        CanSoldierPlacement();
        if (!_barrackData.IsBuild || !_barrackData.IsLocate) return;
        GetSoldier();
    }

    private void CanSoldierPlacement()
    {
        var tiles = GameEvents.GetDictionaryMethod();
        foreach (var tile in tiles)
        {
            if (tile.Value.TileData.TileType != TileTypes.Walkable) continue;
            _barrackData.IsLocate = true;
        }
    }
}
