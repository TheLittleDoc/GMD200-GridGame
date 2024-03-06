// Written by Ella
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public abstract class Weeble
{
    protected Team team;
    protected Type type;
    protected Vector3Int coor;
    protected bool isLive;
    public abstract bool isValidMove(Vector3Int end);
    public abstract Vector3Int[] getValidMoves();
    public virtual bool canBeTakenBy(Weeble weeb)
    {
        return true;
    }
    public bool isAlive()
    {
        return isLive;
    }
    public bool isDead()
    {
        return !isLive;
    }
    public void setDead()
    {
        isLive = false;
    }
    public void setAlive()
    {
        isLive = true;
    }
    public bool isWug()
    {
        return team == Team.Wug;
    }
    public bool isGreeble()
    {
        return team == Team.Greeble;
    }
    public Team getTeam()
    {
        return team;
    }
    public bool isPawn()
    {
        return type == Type.Pawn;
    }
    public bool isDiag()
    {
        return type == Type.Diag;
    }
    public bool isScout()
    {
        return type == Type.Scout;
    }
    public bool isMimic()
    {
        return type == Type.Mimic;
    }
    public bool isKing()
    {
        return type == Type.King;
    }
    public Type getType()
    {
        return type;
    }
    public Vector3Int getCoordinates()
    {
        return coor;
    }
    public virtual void setCoordinates(Vector3Int newCoordinates)
    {
        coor = newCoordinates;
    }
    public enum Type
    {
        Pawn, Diag, Scout, Mimic, King
    };
    public enum Team
    {
        Greeble, Wug
    };
}
