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
}