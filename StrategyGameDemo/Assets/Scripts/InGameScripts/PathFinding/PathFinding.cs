using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour
{
    #region References


    #endregion


    #region Serialize


    #endregion

    #region OnEnable && OnDisable

    private void OnEnable() => GameEvents.OnGetPath += CalculatePath;
    private void OnDisable() => GameEvents.OnGetPath -= CalculatePath;

    #endregion

    private Queue<TileController> CalculatePath(TileController start, TileController goal)
    {
        var nextTileToGoal = new Dictionary<TileController, TileController>();
        var costToReachTile = new Dictionary<TileController, int>();

        var frontier = new PriorityQueue<TileController>();
        frontier.Enqueue(goal, 0);
        costToReachTile[goal] = 0;

        while (frontier.Count > 0)
        {
            var curTile = frontier.Dequeue();
            if (curTile == start)
                break;
            foreach (var neighbor in GameEvents.GetNeighborMethod(curTile))
            {
                int newCost = costToReachTile[curTile] + neighbor.TileData.Cost;
                if (costToReachTile.ContainsKey(neighbor) == false || newCost < costToReachTile[neighbor])
                {
                    if (neighbor.TileData.TileType == TileTypes.Walkable)
                    {
                        costToReachTile[neighbor] = newCost;
                        var priority = newCost + CalculateDistance(neighbor, start);
                        frontier.Enqueue(neighbor, priority);
                        nextTileToGoal[neighbor] = curTile;
                    }
                }
            }
        }
        if (nextTileToGoal.ContainsKey(start) == false)
        {
            return null;
        }
        var path = new Queue<TileController>();
        var pathTile = start;
        while (goal != pathTile)
        {
            pathTile = nextTileToGoal[pathTile];
            path.Enqueue(pathTile);
        }
        return path;
    }

    private int CalculateDistance(TileController t1, TileController t2)
    {
        return Mathf.Abs(t1.TileData.CoordinateX - t2.TileData.CoordinateX) + Mathf.Abs(t1.TileData.CoordinateY - t2.TileData.CoordinateY);
    }
}
