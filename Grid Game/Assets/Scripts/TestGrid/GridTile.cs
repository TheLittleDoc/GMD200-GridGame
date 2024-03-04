// More of Arija causing chaos and messing with stuff

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTile : MonoBehaviour
{
    public GridManagerA gridManager;
    public Vector2Int gridCoords;

    private void OnMouseOver()
    {
        //Tell grid manager that this tile has is being hovered
        gridManager.OnTileHoverEnter(this);
    }

    private void OnMouseExit()
    {
        //Tell grid manager that this tile has been left
        gridManager.OnTileHoverExit(this);

    }
}
