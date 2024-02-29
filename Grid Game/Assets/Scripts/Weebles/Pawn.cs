using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Pawn : Weeble
{
    public override bool isValidMove(Vector3Int end)
    {
        return HexTile.IsNeighbor(coor, end);
    }
    public override Vector3Int[] getValidMoves()
    {
        return HexTile.GetNeighbors(coor);
    }
}
