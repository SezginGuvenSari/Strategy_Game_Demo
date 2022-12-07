using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class BuildingLocator : MonoBehaviour
{

    #region Const

    private const string TileTag = "Tile";

    #endregion

    #region References

    private RaycastHit _hit;

    private float _gridWidth;

    #endregion


    public virtual void Initialize() => _gridWidth = (float)GameEvents.GetTileWidthPositionMethod();

    public virtual void PlacementProcess(Vector3 startPos, BuildingData data)
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (data.IsBuild == false)
            {
                data.IsBuild = true;
                var tile = GameEvents.GetCurrentTilesMethod(startPos, data.Size);
                BuildClicked(tile, data);
                SetDataColorAlpha(data);
            }
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out _hit) || !_hit.transform.CompareTag(TileTag) || data.IsBuild) return;

        var targetPos = ClampTargetPos(startPos);
        transform.position = Vector3.Lerp(transform.position, targetPos, 1f);
    }

    private Vector3 ClampTargetPos(Vector3 startPos)
    {
        var targetPos = new Vector3((_hit.transform.position.x + startPos.x), (_hit.transform.position.y + startPos.y), 0);
        targetPos.x = Mathf.Clamp(targetPos.x, startPos.x, _gridWidth - startPos.x);
        targetPos.y = Mathf.Clamp(targetPos.y, startPos.y, _gridWidth - startPos.y);
        return targetPos;
    }

    public virtual void SetDataColorAlpha(BuildingData data)
    {
        var color = data.SpriteRenderer.color;
        color.a = Mathf.Lerp(color.a, 255f, 1f);
        data.SpriteRenderer.color = color;
    }
    private void BuildClicked(List<TileController> tiles, BuildingData data)
    {
        data.IsBuild = true;
        foreach (var tile in tiles)
        {
            tile.TileData.TileType = TileTypes.UnWalkable;
        }
        tiles.Clear();

    }
}
