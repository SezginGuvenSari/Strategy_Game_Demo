using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPlantController : BuildingLocator , IInteractable
{

    #region References

    private PowerPlantData _powerPlantData;

    #endregion

    #region Serialize


    #endregion

    #region Properties



    #endregion


    private void Awake() => _powerPlantData = GetComponent<PowerPlantData>();

    void Start() => base.Initialize();


    void Update()
    {
        base.PlacementProcess(_powerPlantData.StartPosition, _powerPlantData);
    }


    public void Interact()
    {
        if (_powerPlantData.IsBuild)
        {
            GameEvents.SetBuildingDataMethod(_powerPlantData.ItemImage, _powerPlantData.ItemName);
            print(gameObject.name);
        }
      
    }
}
