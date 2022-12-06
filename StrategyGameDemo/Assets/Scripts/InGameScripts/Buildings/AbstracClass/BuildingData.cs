using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public abstract class BuildingData : MonoBehaviour
{

    #region References

    [SerializeField] private string _itemName;

    [SerializeField] private Sprite _itemImage;

    [SerializeField] private bool _isBuild = false;

    [SerializeField] private Vector3 _startPosition;

    [SerializeField] private SpriteRenderer _spriteRenderer;

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


    #endregion

    private void Start() => _startPosition = transform.position;
}
