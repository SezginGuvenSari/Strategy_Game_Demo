using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public  class BuildingData : MonoBehaviour
{

    #region References

    [SerializeField] private string _itemName;

    [SerializeField] private Sprite _itemImage;

    [SerializeField] private bool _isBuild = false;

    [SerializeField] private Vector3 _startPosition;

    [SerializeField] private SpriteRenderer _spriteRenderer;

    [SerializeField] private Vector2 _size;

    [SerializeField] private List<TileController> _currentTiles;

    [SerializeField] private Color _defaultColor;


    #endregion

    #region Properties

    public string ItemName
    {
        get => _itemName;
        set => _itemName = value;
    }
    public Sprite ItemImage
    {
        get => _itemImage;
        set => _itemImage = value;
    }

    public bool IsBuild
    {
        get => _isBuild;
        set => _isBuild = value;
    }

    public Vector3 StartPosition
    {
        get => _startPosition;
        set => _startPosition = value;
    }

    public SpriteRenderer SpriteRenderer
    {
        get => _spriteRenderer;
        set => _spriteRenderer = value;
    }

    public Vector2 Size
    {
        get => _size;
        set => _size = value;
    }

    public List<TileController> CurrentTiles
    {
        get => _currentTiles;
        set => _currentTiles = value;
    }

    public Color DefaultColor
    {
        get => _defaultColor;
        set => _defaultColor = value;
    }


    #endregion

    private void Start() => _startPosition = transform.position;
}
