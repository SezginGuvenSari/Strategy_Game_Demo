using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TileController : MonoBehaviour
{

    #region Serialize

    [SerializeField] private TileData _tileData;

    #endregion


    #region Properties

    public TileData TileData
    {
        get => _tileData;
        set => _tileData = value;
    }

    #endregion


    public void Init(bool isState) => _tileData.Renderer.color = isState ? _tileData.BaseColor : _tileData.StateColor;

    private void Start()
    {

    }


    void OnMouseEnter() => IsActiveHighlight(true);

    void OnMouseExit() => IsActiveHighlight(false);

    private void IsActiveHighlight(bool on) => _tileData.HighLight.SetActive(on);

  
}
