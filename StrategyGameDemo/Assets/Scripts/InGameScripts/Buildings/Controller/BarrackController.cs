using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrackController : BuildingLocator
{

    #region References

    private BarrackData _barrackData;

    #endregion

    #region Serialize


    #endregion

    #region Properties

    

    #endregion



    private void Awake() => _barrackData = GetComponent<BarrackData>();

    void Start()
    {
        print(_barrackData.ItemName);
        base.Initialize();
    }

    
    void Update()
    {
        base.PlacementProcess(_barrackData.StartPosition,_barrackData);
       
    }


}
