using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierController : MonoBehaviour, IInteractable
{
    #region References

    private SoldierData _soldierData;

    #endregion

    private void Awake() => Initialize();

    private void Initialize() => _soldierData = GetComponent<SoldierData>();

    private void Update() => CalculatePath();

    public void Interact()
    {
        if (!_soldierData.IsBuild) return;
        GameEvents.SetBuildingDataMethod(_soldierData.ItemImage, _soldierData.ItemName);
        _soldierData.StartTile = GameEvents.GetTileInDictionaryWithPositionMethod(new Vector2(transform.position.x, transform.position.y));
    }

    private void CalculatePath()
    {
        if (!Input.GetMouseButtonDown(1)) return;

        var data = GameEvents.GetTileUnderMouseMethod();
        if (data == null) return;

        _soldierData.EndTile = data;

        if (_soldierData.EndTile.TileData.TileType == TileTypes.UnWalkable) return;

        if (_soldierData.StartTile == null || _soldierData.EndTile == null) return;

        _soldierData.EndTile.TileData.TileType = TileTypes.UnWalkable;
        _soldierData.StartTile.TileData.TileType = TileTypes.Walkable;
        var path = GameEvents.GetPathMethod(_soldierData.StartTile, _soldierData.EndTile);
        if (path != null)
        {
            StartCoroutine(SoldierMoveAlongPath(path));
        }
      
    }

    private IEnumerator SoldierMoveAlongPath(Queue<TileController> path)
    {
        var lastPosition = transform.position;
        while (path.Count > 0)
        {
            var nextTile = path.Dequeue();
            float lerpVal = 0;
            while (lerpVal < 1)
            {
                lerpVal += Time.deltaTime * _soldierData.SoldierSpeed;
                transform.position = Vector3.Lerp(lastPosition, nextTile.transform.position, lerpVal);
                yield return new WaitForEndOfFrame();
            }

            yield return new WaitForSeconds(0.5f / _soldierData.SoldierSpeed);
            lastPosition = nextTile.transform.position;
            _soldierData.StartTile = null;
        }
    }
}
