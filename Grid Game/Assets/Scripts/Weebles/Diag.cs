using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Diag : Weeble
{
    public override bool isValidMove(Vector3Int end)
    {
        return HexTile.GetDistance(coor, end) == 2 && coor.x != 0 && coor.y != 0 && coor.z != 0;
    }
    public override Vector3Int[] getValidMoves()
    {
        var list = new List<Vector3Int> {
            new Vector3Int(2, -1, -1) + coor,
			new Vector3Int(1, -2, 1) + coor,
			new Vector3Int(-1, -1, 2) + coor,
			new Vector3Int(-2, 1, 1) + coor,
			new Vector3Int(-1, 2, -1) + coor,
			new Vector3Int(1, 1, -2) + coor

        };
        int i = 0;
        while (i < 6)
        {
            if (list[i].x > 3 || list[i].y > 3 || list[i].z > 3) {
				list.RemoveAt(i);
            } else
            {
                i++;
            }
        }
        return list.ToArray();
    }
}