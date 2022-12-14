using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    #region Serialize

    [SerializeField] private int _width;

    [SerializeField] private int _height;

    [SerializeField] private TileController _tilePrefab;

    [SerializeField] private Transform _tilesParent;

    [SerializeField] private float _spawnDelay;
    #endregion

    #region References

    private const float TileSize = 0.32f;

    private Dictionary<Vector2, TileController> _tiles;

    #endregion

    #region OnEnable & OnDisable
    private void OnEnable()
    {
        GameEvents.OnGetTileInDictionaryWithCoordinates += GetTileWithCoordinates;
        GameEvents.OnGetTileWidthPosition += GetTileWidthPosition;
        GameEvents.OnGetDictionary += GetDictionary;
        GameEvents.OnGetGridWidth += GetGridWidth;
        GameEvents.OnGetTileInDictionaryWithPosition += GetTileWithPosition;
    }
    private void OnDisable()
    {
        GameEvents.OnGetTileInDictionaryWithCoordinates -= GetTileWithCoordinates;
        GameEvents.OnGetTileWidthPosition -= GetTileWidthPosition;
        GameEvents.OnGetDictionary -= GetDictionary;
        GameEvents.OnGetGridWidth -= GetGridWidth;
        GameEvents.OnGetTileInDictionaryWithPosition -= GetTileWithPosition;
    }

    #endregion

    private void Start() =>StartCoroutine(GenerateGrid());
    private IEnumerator GenerateGrid()
    {
        GameEvents.GetCameraSettingsMethod(_width,_height,TileSize);
        _tiles = new Dictionary<Vector2, TileController>();
        for (var x = 0; x < _width; x++)
        {
            var posX = x * TileSize;
            for (var y = 0; y < _height; y++)
            {
                var posY = y * TileSize;
                var tile = Instantiate(_tilePrefab, new Vector3(posX, posY), Quaternion.identity);
                tile.transform.SetParent(_tilesParent);
                tile.name = $"Tile {x}_{y}";
                var data = tile.TileData;
                data.CoordinateX = x;
                data.CoordinateY = y;

                SetTileInDictionary(x, y, tile);
                SetTileColor(x, y, tile);
            }
            yield return new WaitForSeconds(_spawnDelay);
        }
        GameEvents.FindNeighborMethod(_width, _height, _tiles);
    }
    private void SetTileInDictionary(float posX, float posY, TileController tile)
    {
        _tiles[new Vector2(posX, posY)] = tile;
    }
    private void SetTileColor(int x, int y, TileController tile)
    {
        var isState = (x % 2 != y % 2);
        tile.Init(isState);
    }
    private TileController GetTileWithCoordinates(Vector2 pos) => _tiles.TryGetValue(pos, out var tile) ? tile : null;
    private float GetTileWidthPosition() => (_width - 1) * TileSize;
    private Vector2Int GetGridWidth() => new Vector2Int(_width, _height);
    private Dictionary<Vector2, TileController> GetDictionary() => _tiles;
    private TileController GetTileWithPosition(Vector2 pos)
    {
        var posX = Mathf.Round(pos.x / TileSize);
        var posY = Mathf.Round(pos.y / TileSize);
        return _tiles[new Vector2(posX, posY)];
    }

}
