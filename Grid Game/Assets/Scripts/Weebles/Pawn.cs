//Writted by Ella
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
    public override bool canAttack(Weeble weeb)
    {
        return true;
    }
    public Pawn(Team team, Vector3Int coordinates)
    {
        this.team = team;
        type = Type.Pawn;
        coor = coordinates;
        isLive = true;
    }
}
