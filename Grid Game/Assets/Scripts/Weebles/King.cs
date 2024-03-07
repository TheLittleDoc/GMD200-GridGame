//An Ella Writ
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Weeble
{
    public override bool isValidMove(Vector3Int end)
    {
        return HexTile.IsNeighbor(coor, end);
    }
    public override Vector3Int[] getValidMoves()
    {
        return HexTile.GetNeighbors(coor);
    }
    public override bool canAttack(Weeble weeb)
    {
        return true;
    }
    public King(Team team, Vector3Int coordinates)
    {
        this.team = team;
        type = Type.King;
        coor = coordinates;
        isLive = true;
    }
}
