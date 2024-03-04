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
    Vector3Int currentTile = new Vector3Int(0, 0, 0);

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
    public Vector3Int TileCoordToWorldCoord(int x, int y)
    {
        return new Vector3Int(x, y, 0);
    }

    // Moves the selected object to the tile clicked
    public void MoveObject(int x, int y)
    {
        // If selectedTile +/-1 is equal to currentTile, then proceed
        if (TileCoordToWorldCoord(x, y) == currentTile + new Vector3Int(1, 0, 0) || TileCoordToWorldCoord(x, y) == currentTile + new Vector3Int(0, 1, 0) 
            || TileCoordToWorldCoord(x, y) == currentTile + new Vector3Int(-1, 0, 0) || TileCoordToWorldCoord(x, y) == currentTile + new Vector3Int(0, -1, 0))
        {
            selectedObject.transform.position = TileCoordToWorldCoord(x, y);
            currentTile = TileCoordToWorldCoord(x, y);
        } else
        {
            Debug.Log("No! Too far away!");
        }
        
    }
}