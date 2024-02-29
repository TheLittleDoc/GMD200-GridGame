using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public abstract class Weeble
{
    protected WeebleTeam team;
    protected WeebleType type;
    protected Vector3Int coor;
    public abstract bool isValidMove(Vector3Int end);
    public abstract Vector3Int[] getValidMoves();
    public virtual bool canBeTakenBy(Weeble weeb)
    {
        return true;
    }
    public bool isWug()
    {
        return team == WeebleTeam.Wug;
    }
    public bool isGreeble()
    {
        return team == WeebleTeam.Greeble;
    }
    public WeebleTeam getTeam()
    {
        return team;
    }
    public bool isPawn()
    {
        return type == WeebleType.Pawn;
    }
    public bool isDiag()
    {
        return type == WeebleType.Diag;
    }
    public bool isScout()
    {
        return type == WeebleType.Scout;
    }
    public bool isMimic()
    {
        return type == WeebleType.Mimic;
    }
    public bool isKing()
    {
        return type == WeebleType.King;
    }
    public WeebleType getType()
    {
        return type;
    }
    public Vector3Int getCoordinates()
    {
        return coor;
    }
}
public enum WeebleType
{
    Pawn, Diag, Scout, Mimic, King
};
public enum WeebleTeam
{
    Greeble, Wug
};