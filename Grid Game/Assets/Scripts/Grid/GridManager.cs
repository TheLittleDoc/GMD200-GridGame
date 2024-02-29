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
        
        var coordinateToSet = new Vector3Int(0, 0, 0);
        for(var i = 1; i < sideLength; i++)
        {
            //create an empty child
            shells.Add(new GameObject("Shell " + i));
            shells[^1].transform.parent = transform;
            
            coordinateToSet += HexTile.Direction((int)HexTile.Directions.rS);
            var direction = 0;
            var sideCount = 0;
            
            for (var j = 0; j < 6 * i; j++)
            {
                
                var thisDirection = HexTile.Direction(direction);
                sideCount++;
                
                tileList.Add(Instantiate(tilePrefab.gameObject, new Vector3(0, 0, 0), Quaternion.identity));
                //make the new instance a child of the grid manager
                tileList[^1].transform.parent = shells[^1].transform;
                tileList[^1].GetComponent<HexTile>().SetCoordinate(coordinateToSet);
                if(tileList.Count % 2 == 0)
                {
                    tileList[^1].GetComponent<SpriteRenderer>().sprite = tileSprites[0];
                }
                else
                {
                    tileList[^1].GetComponent<SpriteRenderer>().sprite = tileSprites[1];
                }
                if (sideCount == i)
                {
                    direction++;
                    sideCount = 0;
                }
                
                coordinateToSet += thisDirection;
                
            }
        }
        
        
        
        
        
            
        

    }

}
