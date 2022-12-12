using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Test : MonoBehaviour
{

    RaycastHit hit;

    private Vector3 _startPos;

    private float minX = 0;

    private bool isLocate = true;

    public List<TileController> tileList = new List<TileController>();

    private BuildingData data;

    private void Start()
    {
        _startPos = transform.position;
        data = GetComponent<BuildingData>();
    }


    private void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {
        }

    }

    private void WalkableControlSystem(Vector3 startPosition, Vector2 size)
    {
        var dataPosition = new Vector2(transform.position.x - startPosition.x, transform.position.y - startPosition.y);

        var posX = Mathf.Round(dataPosition.x / 0.32f);
        var posY = Mathf.Round(dataPosition.y / 0.32f);
        var startPosY = posY;
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                var tile = GameEvents.GetTileInDictionaryMethod(new Vector2(posX, posY));
                tile.TileData.TileType = TileTypes.UnWalkable;
                posY++;
            }
            posY = startPosY;
            posX++;
        }
    }

}
