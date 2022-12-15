using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
public class SpriteController : MonoBehaviour
{

    #region Serialize

    [SerializeField] private SpriteAtlas _spriteAtlas;

    [SerializeField] private SpriteType _spriteType;

    [SerializeField] private RenderType _renderType;


    #endregion


    void Start() => SetSprite(_renderType);

    private void SetSprite(RenderType renderType)
    {
        if (_renderType == RenderType.SpriteRenderer)
        {
            var sprite = _spriteAtlas.GetSprite(_spriteType.ToString());
            GetComponent<SpriteRenderer>().sprite = sprite;
            GetComponent<BuildingData>().ItemImage = sprite;
        }
        else if (_renderType == RenderType.Image)
        {
            GetComponent<Image>().sprite = _spriteAtlas.GetSprite(_spriteType.ToString());
        }
    }

    public enum RenderType
    {
        SpriteRenderer,
        Image,
    }

}
