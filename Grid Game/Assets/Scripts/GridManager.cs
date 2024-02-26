//Just Arija messing around with things

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int numRows = 5;
    public int numCols = 5;
    public float padding = 0.1f;

    [SerializeField] private GridTile tilePrefab;
    [SerializeField] private TextMeshProUGUI text;

    private void Awake()
    {
        InitGrid();
    }

    public void InitGrid()
    {
        for (int i = 0; i < numRows; i++)
        {
            for (int j = 0; j < numCols; j++)
            {
                GridTile tile = Instantiate(tilePrefab, transform);
                Vector2 tilePos = new Vector2(i + (padding*i), j + (padding*j));
                tile.transform.localPosition = tilePos;
                tile.name = $"Tile_{i}_{j}";
                tile.gridManager = this;
                tile.gridCoords = new Vector2Int(i, j);
            }
        }
    }

    public void OnTileHoverEnter(GridTile gridTile)
    {
        
    }

    public void OnTileHoverExit(GridTile gridTile)
    {

    }
}
