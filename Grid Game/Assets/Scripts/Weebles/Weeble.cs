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
    protected bool isLive = true;
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
    public abstract bool IsValidMove(Vector3Int end);
    public abstract Vector3Int[] GetValidMoves();
    public virtual bool CanAttack(Weeble weeble)
    {
        return weeble.GetTeam() != team && weeble.type != Type.King;
    }
    public virtual void DoAttack(Weeble weeble) {}
    public bool IsAlive()
    {
        return isLive;
    }
    public bool IsDead()
    {
        return !isLive;
    }
    public void SetDead()
    {
        isLive = false;
    }
    public void SetAlive()
    {
        isLive = true;
    }
    public bool IsWug()
    {
        return team == Team.Wug;
    }
    public bool IsGreeble()
    {
        return team == Team.Greeble;
    }
    public Team GetTeam()
    {
        return team;
    }
    public bool IsPawn()
    {
        return type == Type.Pawn;
    }
    public bool IsDiag()
    {
        return type == Type.Diag;
    }
    public bool IsScout()
    {
        return type == Type.Scout;
    }
    public bool IsMimic()
    {
        return type == Type.Mimic;
    }
    public bool IsKing()
    {
        return type == Type.King;
    }
    public bool IsSoup()
    {
        return type == Type.Soup;
    }
    public Type getType()
    {
        return type;
    }
    public Vector3Int GetCoordinates()
    {
        return coor;
    }
    public virtual void SetCoordinates(Vector3Int newCoordinates)
    {
        coor = newCoordinates;
    }
    public enum Type
    {
        Pawn, Diag, Scout, Mimic, King, Soup
    };
    public enum Team
    {
        Greeble, Wug, Soup
    };
}
