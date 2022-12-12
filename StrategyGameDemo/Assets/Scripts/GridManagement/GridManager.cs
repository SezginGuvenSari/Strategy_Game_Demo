using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    #region Serialize

    [SerializeField] private int _width;

    [SerializeField] private int _height;

    [SerializeField] private TileController _tilePrefab;

    [SerializeField] private Transform _cam;

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
        GameEvents.OnGetTileInDictionary += GetTileWithPosition;
        GameEvents.OnGetTileWidthPosition += GetTileWidthPosition;
        GameEvents.OnGetDictionary += GetDictionary;
    }

    private void OnDisable()
    {
        GameEvents.OnGetTileInDictionary -= GetTileWithPosition;
        GameEvents.OnGetTileWidthPosition -= GetTileWidthPosition;
        GameEvents.OnGetDictionary -= GetDictionary;
    }

    #endregion

    private void Start() => StartCoroutine(GenerateGrid());


    private IEnumerator GenerateGrid()
    {
        SetCameraPosition();
        SetCamSize();
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

                SetTileInDictionary(x, y, tile);
                SetTileColor(x, y, tile);
                yield return new WaitForSeconds(_spawnDelay);
            }
        }
        
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

    private void SetCameraPosition()
    {
        _cam.position = new Vector3((float)(_width * TileSize) / 2 - TileSize / 2,
            (float)(_height * TileSize) / 2 - TileSize / 2, -10f);
    }

    private void SetCamSize() => _cam.GetComponent<Camera>().orthographicSize = (_width * TileSize) / 2;


    private TileController GetTileWithPosition(Vector2 pos) => _tiles.TryGetValue(pos, out var tile) ? tile : null;

    private float GetTileWidthPosition() => (_width - 1) * TileSize;


    private Dictionary<Vector2,TileController> GetDictionary() => _tiles;
}
