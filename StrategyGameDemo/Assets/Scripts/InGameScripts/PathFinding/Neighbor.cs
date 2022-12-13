using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neighbor : MonoBehaviour
{
    #region References

    private Dictionary<TileController, TileController[]> _neighborDictionary;

    #endregion

    #region OnEnable && OnDisable

    private void OnEnable()
    {
        GameEvents.OnFindNeighbor += FindNeighbors;
        GameEvents.OnGetNeighbor += GetNeighbors;
    }


    private void OnDisable()
    {
        GameEvents.OnFindNeighbor -= FindNeighbors;
        GameEvents.OnGetNeighbor -= GetNeighbors;
    }

    #endregion

    private void Awake() => _neighborDictionary = new Dictionary<TileController, TileController[]>();

    private void FindNeighbors(int width, int height, Dictionary<Vector2, TileController> tiles)
    {
        for (var x = 0; x < width; x++)
        {
            for (var y = 0; y < height; y++)
            {
                var neighbors = new List<TileController>();

                if (y < height - 1 && tiles.ContainsKey(new Vector2(x, y + 1)))
                    neighbors.Add(tiles[new Vector2(x, y + 1)]);
                if (x < width - 1 && tiles.ContainsKey(new Vector2(x + 1, y)))
                    neighbors.Add(tiles[new Vector2(x + 1, y)]);
                if (y > 0 && tiles.ContainsKey(new Vector2(x, y - 1)))
                    neighbors.Add(tiles[new Vector2(x, y - 1)]);
                if (x > 0 && tiles.ContainsKey(new Vector2(x - 1, y)))
                    neighbors.Add(tiles[new Vector2(x - 1, y)]);

                _neighborDictionary.Add(tiles[new Vector2(x, y)], neighbors.ToArray());
            }
        }

    }

    private TileController[] GetNeighbors(TileController tile)
    {
        return _neighborDictionary[tile];
    }

}
