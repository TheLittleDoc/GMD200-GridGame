//Wrote By Ella
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

class Scout : Weeble
{
    public override bool IsValidMove(Vector3Int end)
    {
        return HexTile.GetDistance(coor, end) < 4;
    }
    public override Vector3Int[] GetValidMoves()
    {
        var list = new List<Vector3Int>();

        for (int i = 0; i < 4; i++)
        {
            for (int j = i == 0 ? 0 : -3; j < 4 - i; j++)
            {
                list.Add(new Vector3Int(i, j, - i - j) + coor);
                list.Add(-new Vector3Int(i, j, - i - j) + coor);
            }
        }
        list.RemoveAt(0);
        removeOutOfBoundsResults(list);
        return list.ToArray();
    }
    public override bool CanAttack(Weeble weeble)
    {
        return weeble.GetTeam() != team && weeble.getType() != Type.King && HexTile.GetDistance(coor, weeble.GetCoordinates()) == 1;
    }
    public Scout(Team team, Vector3Int coordinates)
    {
        this.team = team;
        type = Type.Scout;
        coor = coordinates;
        isLive = true;
    }
}
