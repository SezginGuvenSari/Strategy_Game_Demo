using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLocator : MonoBehaviour
{
    #region References

    private  List<TileController> _tileList;

    #endregion

    #region OnEnable & OnDisable

    private void OnEnable() => GameEvents.OnGetCurrentTiles += GetCurrentTiles;

    private void OnDisable() => GameEvents.OnGetCurrentTiles -= GetCurrentTiles;

    #endregion

    private List<TileController> GetCurrentTiles(Vector3 startPosition, Vector2 size)
    {
         _tileList = new List<TileController>();
        var dataPosition = new Vector2(transform.position.x - startPosition.x, transform.position.y - startPosition.y);
        var posX = Mathf.Round(dataPosition.x / 0.32f);
        var posY = Mathf.Round(dataPosition.y / 0.32f);
        var startPosY = posY;
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                var tile = GameEvents.GetTileInDictionaryMethod(new Vector2(posX, posY));
                _tileList.Add(tile);
                posY++;
            }
            posY = startPosY;
            posX++;
        }
        return _tileList;
    }
}
