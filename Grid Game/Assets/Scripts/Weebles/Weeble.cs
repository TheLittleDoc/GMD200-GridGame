// Written by Ella
using System;
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
    protected void removeOutOfBoundsResults(List<Vector3Int> list)
    {
        int i = 0;
        while (i < list.Count)
        {
            if (Math.Abs(list[i].x) > 3 || Math.Abs(list[i].y) > 3 || Math.Abs(list[i].z) > 3)
            {
                list.RemoveAt(i);
            }
            else
            {
                i++;
            }
        }
        Debug.Log(list.Count);
    }
    public abstract bool isValidMove(Vector3Int end);
    public abstract Vector3Int[] getValidMoves();
    public virtual bool canAttack(Weeble weeb)
    {
        return weeb.type != Type.King;
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
    public bool isSoup()
    {
        return type == Type.Soup;
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
        Pawn, Diag, Scout, Mimic, King, Soup
    };
    public enum Team
    {
        Greeble, Wug
    };
}
