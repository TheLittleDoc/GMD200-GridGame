//An Ella Writ
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Weeble
{
    public override bool IsValidMove(Vector3Int end)
    {
        return HexTile.IsNeighbor(coor, end);
    }
    public override Vector3Int[] GetValidMoves()
    {
        return HexTile.GetNeighbors(coor);
    }
    public override bool CanAttack(Weeble weeble)
    {
        return weeble.GetTeam() != team;
    }
    public King(Team team, Vector3Int coordinates)
    {
        this.team = team;
        type = Type.King;
        coor = coordinates;
        isLive = true;
    }
}
