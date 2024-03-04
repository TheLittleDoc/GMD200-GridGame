using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTile : MonoBehaviour
{
    public int tileX;
    public int tileY;
    public TilesThree tiles;

    private void OnMouseDown()
    {
        tiles.MoveObject(tileX, tileY);
    }
}
