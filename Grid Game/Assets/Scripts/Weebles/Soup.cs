//Writted by Ella
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using UnityEngine;

public class Soup : Weeble
{
    public override bool IsValidMove(Vector3Int end)
    {
        return false;
    }
    public override Vector3Int[] GetValidMoves()
    {
        return new Vector3Int[0];
    }
    public override bool CanAttack(Weeble weeble)
    {
        return false;
    }
    public Soup(Team team, Vector3Int coordinates)
    {
        this.team = team;
        type = Type.Soup;
        coor = coordinates;
        isLive = true;
    }
}
