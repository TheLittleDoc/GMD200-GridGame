//Wrote By Ella
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

class Scout : Weeble
{
    public override bool isValidMove(Vector3Int end)
    {
        return HexTile.GetDistance(coor, end) < 4;
    }
    public override Vector3Int[] getValidMoves()
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
    public override bool canAttack(Weeble weeb)
    {
        return weeb.getTeam() != team && weeb.getType() != Type.King && HexTile.GetDistance(coor, weeb.getCoordinates()) == 1;
    }
    public Scout(Team team, Vector3Int coordinates)
    {
        this.team = team;
        type = Type.Scout;
        coor = coordinates;
        isLive = true;
    }
}
