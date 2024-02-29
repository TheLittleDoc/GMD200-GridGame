using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

class Scout : Weeble
{
    public override bool isValidMove(Vector3Int end)
    {
        return HexTile.GetDistance(coor, end) < 4;
    }
    public override Vector3Int[] getValidMoves()
    {
        var list = new List<Vector3Int>();

        for (int i = 0; i < 4; i++)
        {
            for (int j = i == 0 ? 0 : -3; j < 4 - i; j++)
            {
                if (i + coor.x > 3 || j + coor.y > 3 || coor.z - i - j > 3)
                {
					list.Add(new Vector3Int(i + coor.x, j + coor.y, coor.z - i - j));
					list.Add(-(new Vector3Int(i + coor.x, j + coor.y, coor.z - i - j)));
                }
            }
        }
		list.RemoveAt(0);
        return list.ToArray();
    }
}
