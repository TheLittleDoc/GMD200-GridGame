using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class GridManager : MonoBehaviour
{
    [SerializeField] private GameObject tilePrefab;

    [SerializeField] private int sideLength = 4;
    
    public List<GameObject> tileList;
    public List<GameObject> shells;
    public List<Sprite> tileSprites;
    private Vector3Int coordinateToSet = new Vector3Int(0, 0, 0);
    
    private int direction = 0;
    private int sideCount = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        tileList = new List<GameObject>
        {
            Instantiate(tilePrefab.gameObject, new Vector3(0, 0, 0), Quaternion.identity)
            
        };
        
        //set coordinate
        tileList[0].GetComponent<HexTile>().SetCoordinate(new Vector3Int(0, 0, 0));
        tileList[0].transform.parent = transform;
        tileList[0].GetComponent<SpriteRenderer>().sprite = tileSprites[0];
        
        
        
        
        
        
            
        

    }

    private void OnEnable()
    {
        coordinateToSet = new Vector3Int(0, 0, 0);
        
        for(var i = 1; i < sideLength; i++)
        {
            //create an empty child
            shells.Add(new GameObject("Shell " + i));
            shells[^1].transform.parent = transform;
            
            coordinateToSet += HexTile.Direction((int)HexTile.Directions.rS);
            direction = 0;
            sideCount = 0;
            
            for (var j = 0; j < 6 * i; j++)
            {
                
                sideCount++;
                
                
                StartCoroutine(SetCoordinate(coordinateToSet, i));
                var wait = new WaitForSecondsRealtime(0.1f);
                
                
            }
        }
    }

    IEnumerator SetCoordinate(Vector3Int coordinate, int i)
    {
        
        var thisDirection = HexTile.Direction(direction);
        tileList.Add(Instantiate(tilePrefab.gameObject, new Vector3(0, 0, 0), Quaternion.identity));
        //make the new instance a child of the grid manager
        tileList[^1].transform.parent = shells[^1].transform;
        Debug.Log("Setting coordinate");
        tileList[^1].GetComponent<HexTile>().SetCoordinate(coordinate);
        tileList[^1].GetComponent<SpriteRenderer>().sprite = tileList.Count % 2 == 0 ? tileSprites[1] : tileSprites[2];
        if (sideCount == i)
        {
            direction++;
            sideCount = 0;
        }
                
        coordinateToSet += thisDirection;
        yield return null;
    }
    
    

}
