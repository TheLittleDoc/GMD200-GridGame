// Yet again another attempt by Arija

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesThree : MonoBehaviour
{
    [field: SerializeField] GameObject selectedObject;
    [field: SerializeField] GameObject tilePrefab;
    int[,] tiles;
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

                // Give the tile click Component
                ClickTile ct = go.GetComponent<ClickTile>();
                ct.tileX = i;
                ct.tileY = j;
                ct.tiles = this;
            }
        }
    }

    // Returns the coords of the tile
    public Vector3 TileCoordToWorldCoord(int x, int y)
    {
        return new Vector3(x, y, 0);
    }

    // Moves the selected object to the tile clicked
    public void MoveObject(int x, int y)
    {
        selectedObject.transform.position = TileCoordToWorldCoord (x, y);
    }
}