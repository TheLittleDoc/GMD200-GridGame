//Started by Ely
//Heavily written by Ella
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
    public static Dictionary<Vector3Int, Transform> tileDict = new Dictionary<Vector3Int, Transform>();
    private Vector3Int coordinateToSet = new Vector3Int(0, 0, 0);
    
    private int direction = 0;
    private int sideCount = 0;
    
    private Camera _camera;
    private GameObject _currentTile;
    private GameObject _previousTile;
    private GameObject _selectedWeeble;
    private GamePiece _selectedGamePiece;
    private Vector3Int[] _validMoves;

    // Start is called before the first frame update
    void Start()
    {
        Debug.developerConsoleVisible = true;
        _camera = Camera.main;
        tileList = new List<GameObject>
        {
            Instantiate(tilePrefab.gameObject, new Vector3(0, 0, 0), Quaternion.identity)
            
        };
        tileDict[new Vector3Int(0, 0, 0)] = tileList[^1].transform;
        //set coordinate
        tileList[0].GetComponent<HexTile>().SetCoordinate(new Vector3Int(0, 0, 0));
        tileList[0].transform.parent = transform;
        tileList[0].GetComponent<SpriteRenderer>().sprite = tileSprites[0];
        tileList[0].GetComponent<SpriteRenderer>().sortingOrder = -999;
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


                tileDict.Add(tileList[^1].GetComponent<HexTile>().GetCoordinate(), tileList[^1].transform);
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
        tileList[^1].GetComponent<SpriteRenderer>().sortingOrder = -999;
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
            if (_currentTile.GetComponent<SpriteRenderer>().color == Color.white)
            {
                _currentTile.GetComponent<SpriteRenderer>().color = Color.yellow;
            }
            if (_previousTile && _previousTile.GetComponent<SpriteRenderer>().color == Color.yellow)
            {
                _previousTile.GetComponent<SpriteRenderer>().color = Color.white;
            }
            //Debug.Log(HexTile.GetDistance(_currentTile.GetComponent<HexTile>().Coordinate, Vector3Int.zero));
            
        } else if (_currentTile == null && _previousTile != null)
        {
            if (_previousTile.GetComponent<SpriteRenderer>().color == Color.yellow)
            {
                _previousTile.GetComponent<SpriteRenderer>().color = Color.white;
            }
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
                //on a tile
                Debug.Log("Tile clicked: " + _currentTile.GetComponent<HexTile>().Coordinate);
                GetComponent<AudioSource>().Play();

                if (_selectedWeeble == null)
                {
                    //play popping sound
                    //no thisWeeble yet selected
                    if (_currentTile.transform.childCount > 0 && _currentTile.transform.GetChild(0).GetComponent<GamePiece>().thisWeeble.GetTeam() == Gameplay.GetTurn())
                    {
                        //valid thisWeeble
                        _currentTile.GetComponent<SpriteRenderer>().color = Color.red;
                        _selectedWeeble = _currentTile.transform.GetChild(0).gameObject;
                        _selectedGamePiece = _selectedWeeble.GetComponent<GamePiece>();
                        _validMoves = _selectedGamePiece.thisWeeble.GetValidMoves();
                        foreach (Vector3Int coor in _validMoves)
                        {
                            if (tileDict[coor].childCount == 0 || _selectedGamePiece.thisWeeble.CanAttack(tileDict[coor].GetChild(0).GetComponent<GamePiece>().thisWeeble))
                                tileDict[coor].GetComponent<SpriteRenderer>().color = Color.green;
                        }
                    }
                } else
                {
                    //trying to move thisWeeble
                    if (!_selectedWeeble.transform.IsChildOf(_currentTile.transform))
                    {
                        //not trying to move to self
                        if (_currentTile.transform.childCount > 0)
                        {
                            //already a thisWeeble here
                            if (_selectedGamePiece.thisWeeble.CanAttack(_currentTile.transform.GetChild(0).GetComponent<GamePiece>().thisWeeble))
                            {
                                //attack is allowed
                                if (_selectedGamePiece.MoveGreeble(_currentTile.GetComponent<HexTile>().Coordinate))
                                {
                                    if (_currentTile.transform.GetChild(0).GetComponent<GamePiece>().thisWeeble
                                        .IsSoup())
                                    {
                                        GameManager.GameOver();
                                    }
                                    //move is allowed
                                    _selectedGamePiece.thisWeeble.DoAttack(_currentTile.transform.GetChild(0).GetComponent<GamePiece>().thisWeeble);
                                    CleanupWeebleMove();
                                    Destroy(_currentTile.transform.GetChild(0).gameObject);
                                } else
                                {
                                    //move is disallowed
                                    DeselectWeeble();
                                }
                            } else
                            {
                                //attack is disallowed
                                DeselectWeeble();
                            }
                        } else if (_selectedGamePiece.MoveGreeble(_currentTile.GetComponent<HexTile>().Coordinate))
                        {
                            //if it's a valid move
                            CleanupWeebleMove();
                        } else
                        {
                            //bad destination
                            DeselectWeeble();
                        }
                    } else
                    {
                        //trying to move to self
                        DeselectWeeble();
                    }
                }

            }
        }
    }
    
    private void DeselectWeeble()
    {
        _selectedWeeble.transform.parent.GetComponent<SpriteRenderer>().color = Color.white;
        _selectedWeeble = null;
        _selectedGamePiece = null;
        foreach (Vector3Int coor in _validMoves)
        {
            tileDict[coor].GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
    private void CleanupWeebleMove()
    {
        _selectedWeeble.transform.parent.GetComponent<SpriteRenderer>().color = Color.white;
        _selectedWeeble.transform.parent = _currentTile.transform;
        _selectedWeeble = null;
        foreach (Vector3Int coor in _validMoves)
        {
            tileDict[coor].GetComponent<SpriteRenderer>().color = Color.white;
        }
        Gameplay.ToggleTurn();
    }
    

}
