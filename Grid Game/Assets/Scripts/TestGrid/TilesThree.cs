using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesThree : MonoBehaviour
{
    [field: SerializeField] GameObject selectedUnit;
    [field: SerializeField] GameObject tilePrefab;
    // int[,] tiles;
    int mapSizeX = 10;
    int mapSizeY = 10;

    void Start()
    {
        GenerateMap();
        /*// Map tiles
        tiles = new int[mapSizeX, mapSizeY];

        // Initialize tiles
        for (int i = 0; i < mapSizeX; i++)
        {
            for (int j = 0; j < mapSizeY; j++)
            {
                tiles[i, j] = 0;
            }
        }*/
    }

    private void GenerateMap()
    {
        // Initialize Tiles
        for (int i = 0; i < mapSizeX; i++)
        {
            for (int j = 0; j < mapSizeY; j++)
            {
                GameObject go = (GameObject)Instantiate(tilePrefab, new Vector3 (i, j, 0), Quaternion.identity);

                ClickTile ct = go.GetComponent<ClickTile>();
                ct.tileX = i;
                ct.tileY = j;
                ct.tiles = this;
            }
        }
    }

    public Vector3 TileCoordToWorldCoord(int x, int y)
    {
        return new Vector3(x, y, 0);
    }

    public void MoveObject(int x, int y)
    {
        tilePrefab.transform.position = TileCoordToWorldCoord (x, y);
    }
}