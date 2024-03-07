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
    public override bool canAttack(Weeble weeb)
    {
        return mask.canAttack(weeb);
    }
    public override void doAttack(Weeble weeb)
    {
        switch (weeb.getType())
        {
            case Weeble.Type.Pawn:
                mask = new Pawn(team, coor);
                break;
            case Weeble.Type.Diag:
                mask = new Diag(team, coor);
                break;
            case Weeble.Type.Mimic:
                mask = new Mimic(team, coor);
                break;
            case Weeble.Type.Scout:
                mask = new Scout(team, coor);
                break;
            case Weeble.Type.King:
                mask = new King(team, coor);
                break;
        }
    }
    public override void setCoordinates(Vector3Int newCoordinates)
    {
        coor = newCoordinates;
        mask.setCoordinates(newCoordinates);
    }
}