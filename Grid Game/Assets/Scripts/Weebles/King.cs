using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Pawn
{
    public override bool canBeTakenBy(Weeble weeb)
    {
        return weeb.isPawn() || weeb.isKing();
    }
}
