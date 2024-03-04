// Written (for an attempt) by Arija

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTile : MonoBehaviour
{
    public int tileX;
    public int tileY;
    public TilesThree tiles;

    // When mouse clicks, calls function from TilesThree, there it gets position and moves object
    private void OnMouseDown()
    {
        tiles.MoveObject(tileX, tileY);
    }
}
