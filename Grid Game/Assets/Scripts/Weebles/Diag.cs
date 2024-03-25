//Ella wroted this
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Diag : Weeble
{
    public override bool IsValidMove(Vector3Int end)
    {
        return HexTile.GetDistance(coor, end) == 2 && end.x - coor.x != 0 && end.y - coor.y != 0 && end.z - coor.z != 0;
    }
    public override Vector3Int[] GetValidMoves()
    {
        var list = new List<Vector3Int> {
            new Vector3Int(2, -1, -1) + coor,
			new Vector3Int(1, -2, 1) + coor,
			new Vector3Int(-1, -1, 2) + coor,
			new Vector3Int(-2, 1, 1) + coor,
			new Vector3Int(-1, 2, -1) + coor,
			new Vector3Int(1, 1, -2) + coor

        };
        removeOutOfBoundsResults(list);
        return list.ToArray();
    }
    public Diag(Team team, Vector3Int coordinates)
    {
        this.team = team;
        type = Type.Diag;
        coor = coordinates;
        isLive = true;
    }
}