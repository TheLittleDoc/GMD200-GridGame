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
    
    private GameObject mouseSprite;
    private Camera _camera;
    private GameObject _currentTile;
    private GameObject _previousTile;
    private GameObject _testGreeble;

    // Start is called before the first frame update
    void Start()
    {
        Debug.developerConsoleVisible = true;
        _camera = Camera.main;
        tileList = new List<GameObject>
        {
            Instantiate(tilePrefab.gameObject, new Vector3(0, 0, 0), Quaternion.identity)
            
        };
        
        //set coordinate
        tileList[0].GetComponent<HexTile>().SetCoordinate(new Vector3Int(0, 0, 0));
        tileList[0].transform.parent = transform;
        tileList[0].GetComponent<SpriteRenderer>().sprite = tileSprites[0];
        
        mouseSprite = new GameObject("Mouse Sprite");
        mouseSprite.AddComponent<SpriteRenderer>();
        mouseSprite.GetComponent<SpriteRenderer>().sprite = tileSprites[0];
        
        
        
        _testGreeble = GameObject.FindGameObjectWithTag("Greeble");
        
        
            
        

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
    
    // Update is called once per frame
    void Update()
    {
        //get the mouse position
        var mousePos = Input.mousePosition;
        
        //convert the mouse position to world space
        mousePos = _camera.ScreenToWorldPoint(mousePos);

        _previousTile = _currentTile == _previousTile ? _previousTile : _currentTile;
        _currentTile = (Physics2D.OverlapPoint(mousePos)) ? Physics2D.OverlapPoint(mousePos).gameObject : null;
        
        
        if (_currentTile != null && _currentTile.GetComponent<HexTile>() != null && _currentTile != _previousTile)
        {
            //Debug.Log("tile is: " + _currentTile.GetComponent<HexTile>().Coordinate);
            _currentTile.GetComponent<SpriteRenderer>().color = Color.yellow;
            if(_previousTile)
                _previousTile.GetComponent<SpriteRenderer>().color = Color.white;
            Debug.Log(HexTile.GetDistance(_currentTile.GetComponent<HexTile>().Coordinate, Vector3Int.zero));
            
        } else if (_currentTile == null && _previousTile != null)
        {
            _previousTile.GetComponent<SpriteRenderer>().color = Color.white;
        }
        
        
        
        CheckInput();
        
        
        
        
    }
    
    //temp
    private void CheckInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_currentTile != null)
            {
                Debug.Log("Tile clicked: " + _currentTile.GetComponent<HexTile>().Coordinate);
                _testGreeble.GetComponent<GreebleTestEly>().MoveGreeble(_currentTile.GetComponent<HexTile>().Coordinate);
            }
        }
    }
    
    

}
