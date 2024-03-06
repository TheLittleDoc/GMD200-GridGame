//Ella was here
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Mimic : Weeble
{
    private Weeble mask;

    public override bool isValidMove(Vector3Int end)
    {
        return mask.isValidMove(end);
    }

    public override Vector3Int[] getValidMoves()
    {
        return mask.getValidMoves();
    }
    public Mimic(Team team, Vector3Int coordinates)
    {
        this.team = team;
        type = Type.Mimic;
        coor = coordinates;
        isLive = true;
        mask = new Pawn(team, coordinates);
    }
    public override void setCoordinates(Vector3Int newCoordinates)
    {
        coor = newCoordinates;
        mask.setCoordinates(newCoordinates);
    }
}