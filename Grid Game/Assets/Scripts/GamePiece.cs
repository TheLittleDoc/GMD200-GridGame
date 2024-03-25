//Written By Ely
//Modified by Ella
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GamePiece : MonoBehaviour
{

    [SerializeField] private Vector3Int _startingPosition;
    [SerializeField] private Weeble.Type _type;
    [SerializeField] private Weeble.Team _team;
    [SerializeField] private List<GameObject> _eyes;
    [SerializeField] private List<Sprite> _bodies;
    public const int _NUMBER_OF_WEEBS_STARTING_ON_FIELD = 14;
    public Weeble thisWeeble;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.parent = GridManager.tileDict[_startingPosition];
        //transform.position = HexTile.GridToWorldspace(new Vector3Int(_startingPosition.x, _startingPosition.y, _startingPosition.z));

        

        switch (_type)
        {
            case Weeble.Type.Pawn:
                GetComponent<SpriteRenderer>().color = new Color(0.7f, .3f, .7f, 1);
                thisWeeble = new Pawn(_team, _startingPosition);
                break;
            case Weeble.Type.Diag:
                GetComponent<SpriteRenderer>().color = new Color(0.8f, .5f, .0f, 1);
                thisWeeble = new Diag(_team, _startingPosition);
                break;
            case Weeble.Type.Mimic:
                GetComponent<SpriteRenderer>().color = new Color(0.7f, .08f, .08f, 1);
                thisWeeble = new Mimic(_team, _startingPosition);
                break;
            case Weeble.Type.Scout:
                GetComponent<SpriteRenderer>().color = new Color(0.2f, .6f, .7f, 1);
                thisWeeble = new Scout(_team, _startingPosition);
                break;
            case Weeble.Type.King:
                GetComponent<SpriteRenderer>().color = new Color(0.17f, .17f, .17f, 1);
                thisWeeble = new King(_team, _startingPosition);
                break;
            case Weeble.Type.Soup:
                thisWeeble = new Soup(_team, _startingPosition);
                break;
        }
        
        switch (_team)
        {
            case Weeble.Team.Greeble:
                if (!thisWeeble.IsSoup())
                {
                    GetComponent<SpriteRenderer>().sprite = _bodies[0];
                    Instantiate(_eyes[0], transform);
                }
                
                
                break;
            case Weeble.Team.Wug:
                if (!thisWeeble.IsSoup())
                {
                    GetComponent<SpriteRenderer>().sprite = _bodies[1];
                }
                
                break;
                
        }
    }
    
    

    // Update is called once per frame
    void Update()
    {
        if(GameManager.isGameOver)
        {
            return;
        }
        if(thisWeeble.IsDead())
        {
            return;
        }
        var rotation = Camera.main.transform.rotation;
        transform.rotation = rotation;
        //layer based on y position
        
        if (rotation.z > 0.5f)
        {
            GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(transform.position.y * 100);
            if(thisWeeble.GetTeam() == Weeble.Team.Greeble)
                if (!thisWeeble.IsSoup())
                    transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(transform.position.y * 100)+1;
        }
        else
        {
            GetComponent<SpriteRenderer>().sortingOrder = -Mathf.RoundToInt(transform.position.y * 100);
            if(thisWeeble.GetTeam() == Weeble.Team.Greeble)
                if (!thisWeeble.IsSoup())
                    transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = -Mathf.RoundToInt(transform.position.y * 100)+1;
        }
        
        
    }
    public bool MoveGreeble(Vector3Int newCoordinate)
    {
        if (thisWeeble.IsValidMove(newCoordinate))
        {
            //dotween
            transform.DOMove(HexTile.GridToWorldspace(new Vector3Int(newCoordinate.x, newCoordinate.y, newCoordinate.z)), 0.5f);
            thisWeeble.SetCoordinates(newCoordinate);
            return true;
        }
        return false;
    }
}
