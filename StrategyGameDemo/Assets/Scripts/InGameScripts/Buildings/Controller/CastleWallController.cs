using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleWallController : BuildingLocator , IInteractable
{

    #region References

    private CastleWallData _castleWallData;

    #endregion

    #region Serialize


    #endregion


    private void Awake() => _castleWallData = GetComponent<CastleWallData>();

    void Start() => base.Initialize();

    void Update() => base.PlacementProcess(_castleWallData.StartPosition,_castleWallData);

    public void Interact()
    {
        if(!_castleWallData.IsBuild) return;
        GameEvents.SetBuildingDataMethod(_castleWallData.ItemImage, _castleWallData.ItemName);
    }
}
