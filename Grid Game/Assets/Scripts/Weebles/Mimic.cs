//Ella was here
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Mimic : Weeble
{
    private Weeble mask;

    public override bool IsValidMove(Vector3Int end)
    {
        return mask.IsValidMove(end);
    }

    public override Vector3Int[] GetValidMoves()
    {
        return mask.GetValidMoves();
    }
    public Mimic(Team team, Vector3Int coordinates)
    {
        this.team = team;
        type = Type.Mimic;
        coor = coordinates;
        isLive = true;
        mask = new Pawn(team, coordinates);
    }
    public override bool CanAttack(Weeble weeble)
    {
        return mask.CanAttack(weeble);
    }
    public override void DoAttack(Weeble weeb)
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
    public override void SetCoordinates(Vector3Int newCoordinates)
    {
        coor = newCoordinates;
        mask.SetCoordinates(newCoordinates);
    }
}