using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarrackData : BuildingData
{
    #region Serialize

    [SerializeField] private string _productionName;

    [SerializeField] private Sprite _productionImage;

    [SerializeField] private bool _isLocate = false;

    #endregion

    #region Properties

    public string ProductionName
    {
        get => _productionName;
        set => _productionName = value;
    }

    public Sprite ProductionImage
    {
        get => _productionImage;
        set => _productionImage = value;
    }

    public bool IsLocate
    {
        get => _isLocate;
        set => _isLocate = value;
    }
    #endregion

  
}
