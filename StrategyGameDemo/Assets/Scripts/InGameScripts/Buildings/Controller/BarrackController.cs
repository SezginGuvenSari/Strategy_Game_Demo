using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrackController : BuildingLocator , IInteractable
{

    #region References

    private BarrackData _barrackData;

    #endregion

    #region Serialize


    #endregion

    #region Properties

    

    #endregion



    private void Awake() => _barrackData = GetComponent<BarrackData>();

    void Start() => base.Initialize();


    void Update()
    {
        base.PlacementProcess(_barrackData.StartPosition, _barrackData);
    }

    public void Interact()
    {
        if (_barrackData.IsBuild)
        {
           GameEvents.SetBuildingDataMethod(_barrackData.ItemImage,_barrackData.ItemName);
           GameEvents.SetProductionDataMethod(_barrackData.ProductionImage,_barrackData.ProductionName);
            print(gameObject.name);
        }
    }
}
