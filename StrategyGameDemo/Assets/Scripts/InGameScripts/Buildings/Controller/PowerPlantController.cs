using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPlantController : BuildingLocator
{

    #region References

    private PowerPlantData _powerPlantData;

    #endregion

    #region Serialize


    #endregion

    #region Properties



    #endregion


    private void Awake() => _powerPlantData = GetComponent<PowerPlantData>();

    void Start()
    {
        base.Initialize();
     
    }


    void Update()
    {
        base.PlacementProcess(_powerPlantData.StartPosition,_powerPlantData);
       
    }

    
}
