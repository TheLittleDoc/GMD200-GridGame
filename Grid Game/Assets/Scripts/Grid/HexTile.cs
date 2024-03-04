using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

public class HexTile : MonoBehaviour
{
    private static Vector3Int[] _directions = new Vector3Int[]
    {
        new Vector3Int(1, 0, -1),
        new Vector3Int(0, 1, -1),
        new Vector3Int(-1, 1, 0),
        new Vector3Int(-1, 0, 1),
        new Vector3Int(0, -1, 1),
        new Vector3Int(1, -1, 0)
    };
    
     public enum Directions {Qs, Rs, qR, qS, rS, Qr}
    
    // Start is called before the first frame update
    //private bool _isOccupied;
    //private bool _isHighlighted;
    //private bool _isSelectable;
    private Vector3Int coordinate = Vector3Int.zero;
    private GameObject _tile;
    private Camera _camera;
    
    

    private void Awake()
    {
        _camera = Camera.main;
    }

    public void SetCoordinate(Vector3Int newCoordinate)
    {
        coordinate = newCoordinate;
        Vector3 newPosition = Vector3.zero;
        newPosition.y = -newCoordinate.y * (float)Math.Sqrt(3)/2;
        newPosition.y -= newCoordinate.x * (float)Math.Sqrt(3)/4;
        newPosition.x = newCoordinate.x * .75f;
        
        //transform.position = newPosition;
        transform.DOMove(newPosition, 0.5f);

    }
    
    //trigger when coordinate is changed
    public Vector3Int Coordinate
    {
        get => coordinate;
        set
        {
            coordinate = value;
            SetCoordinate(value);
        }
    }

    public static Vector3Int Direction(int direction)
    {
        return _directions[(int)direction];
    }
    
    private static Vector3Int GetNeighbor(Vector3Int coordinate, Vector3Int direction)
    {
        return coordinate + direction;
    }

    public HexTile()
    {
        
        //_isOccupied = false;
        //_isHighlighted = false;
        //_isSelectable = false;
        
        
    }

    private string GetCoord()
    {
        return coordinate.x + ", " + coordinate.y + ", " + coordinate.z;
    }
    
    public static Vector3Int[] GetNeighbors(Vector3Int coordinate)
    {
        Vector3Int[] neighbors = new Vector3Int[6];
        for (int i = 0; i < 6; i++)
        {
            var checkDirection = 
            neighbors[i] = GetNeighbor(coordinate, Direction(i));
        }

        return neighbors;
    }

    public static bool IsNeighbor(Vector3Int coordinate, Vector3Int target) { return GetDistance(coordinate, target) == 1; }

    public static int GetDistance(Vector3Int a, Vector3Int b)
    {
        // Get the number of moves away a tile is from another tile
        var aNew = Vector3Int.zero;
        var bNew = b - a;
        // get greatest absolute value from bNew
        var max = Mathf.Max(Mathf.Abs(bNew.x), Mathf.Abs(bNew.y), Mathf.Abs(bNew.z));
        return max;

    }
    

    public static Vector3Int RoundToNearestHex(Vector3 mousePos)
    {
        var coord = new Vector3Int
        {
            x = Mathf.RoundToInt((mousePos.x * (2f/3f)) / (float)Math.Sqrt(3)),
            y = Mathf.RoundToInt((-mousePos.y * (2f/3f)) / (float)Math.Sqrt(3)),
            z = Mathf.RoundToInt(((-mousePos.x * (2f/3f)) - (mousePos.y * (2f/3f))) / (float)Math.Sqrt(3))

        };
        return coord;
    }

    public static Vector3Int WorldspaceToGrid(Vector2 worldCoord)
    {
        var coord = new Vector3Int();
        
        //convert world space to hex coordinate as is implemented above
        coord.x = Mathf.RoundToInt((worldCoord.x * (2f/3f)) / (float)Math.Sqrt(3));
        coord.y = Mathf.RoundToInt((-worldCoord.y * (2f/3f)) / (float)Math.Sqrt(3));
        coord.z = Mathf.RoundToInt(((-worldCoord.x * (2f/3f)) - (worldCoord.y * (2f/3f))) / (float)Math.Sqrt(3));
        
        
        
        return coord;
    }
    
    
    public static Vector2 GridToWorldspace(Vector3Int gridCoord)
    {
        var worldCoord = new Vector2();
        worldCoord.x = gridCoord.x * .75f;
        worldCoord.y = -gridCoord.y * (float)Math.Sqrt(3)/2;
        worldCoord.y -= gridCoord.x * (float)Math.Sqrt(3)/4;
        return worldCoord;
    }
}
