using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TileData : MonoBehaviour
{

    #region Serialize

    [SerializeField] private Color _baseColor;

    [SerializeField] private Color _stateColor;

    [SerializeField] private GameObject _highlight;

    [SerializeField] private TileTypes _tileType;

    [SerializeField] private SpriteRenderer _renderer;

    #endregion


    #region Properties

    public Color BaseColor
    {
        get => _baseColor;
        set => _baseColor = value;
    }

    public Color StateColor
    {
        get => _stateColor;
        set => _stateColor = value;
    }

    public GameObject HighLight
    {
        get => _highlight;
        set => _highlight = value;
    }

    public  TileTypes TileType
    {
        get => _tileType;
        set => _tileType = value;
    }

    public SpriteRenderer Renderer
    {
        get => _renderer;
        set => _renderer = value;
    }

    #endregion

}
