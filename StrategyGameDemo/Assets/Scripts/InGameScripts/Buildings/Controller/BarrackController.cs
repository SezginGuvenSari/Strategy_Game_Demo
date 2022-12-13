using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrackController : BuildingLocator, IInteractable
{

    #region References

    private BarrackData _barrackData;

    private bool _soldierSpawned = false;

    #endregion

    #region Serialize


    #endregion

    #region Properties



    #endregion


    private void Awake() => _barrackData = GetComponent<BarrackData>();

    void Start() => base.Initialize();


    void Update() => base.PlacementProcess(_barrackData.StartPosition, _barrackData);

    public void Interact()
    {
        if (!_barrackData.IsBuild) return;
        GameEvents.SetBuildingDataMethod(_barrackData.ItemImage, _barrackData.ItemName);
        GameEvents.SetProductionDataMethod(_barrackData.ProductionImage, _barrackData.ProductionName);
        GetSoldier();
    }

    private void GetSoldier()
    {
        if (_soldierSpawned) return;
        var soldier = GameEvents.GetObjectsInPoolMethod(ObjectTypes.Soldier);
        var soldierData = soldier.GetComponent<SoldierData>();
        soldierData.IsBuild = true;
        _soldierSpawned = true;
        FindSuitableLocation(soldier.transform);
    }

    private void FindSuitableLocation(Transform soldier)
    {
        while (true)
        {
            var grid = GameEvents.GetGridWidthMethod();
            var posX = Random.Range(0, grid.x);
            var posY = Random.Range(0, grid.y);
            var tile = GameEvents.GetTileInDictionaryMethod(new Vector2(posX, posY));

            if (tile.TileData.TileType != TileTypes.Walkable) continue;

            tile.TileData.TileType = TileTypes.UnWalkable;
            soldier.position = tile.transform.position;
            break;
        }
    }
}
