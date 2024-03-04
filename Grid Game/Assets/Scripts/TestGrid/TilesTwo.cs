// Failed by Arija

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesTwo : MonoBehaviour
{
    public GameObject tileVisualPrefab;
    int[,] tiles;
    int mapSizeX = 10;
    int mapSizeY = 10;

    void Start()
    {
        tiles = new int[mapSizeX, mapSizeY];

        for (int i = 0; i < mapSizeX; i++)
        {
            for (int j = 0; j < mapSizeY; j++)
            {
                tiles[i, j] = 0;
            }
        }
    }
}
