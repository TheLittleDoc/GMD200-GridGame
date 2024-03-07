//Written By Ely
//Heavily Modified by Ella
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GamePiece : MonoBehaviour
{

    [SerializeField] private Vector3Int _startingPosition;
    [SerializeField] private Weeble.Type _type;
    [SerializeField] private Weeble.Team _team;
    public const int _NUMBER_OF_WEEBS_STARTING_ON_FIELD = 14;
    public Weeble weeb;
    // Start is called before the first frame update
    void Start()
    {
        transform.parent = GridManager.tileDict[_startingPosition];
        //transform.position = HexTile.GridToWorldspace(new Vector3Int(_startingPosition.x, _startingPosition.y, _startingPosition.z));
        
        switch (_type)
        {
            case Weeble.Type.Pawn:
                weeb = new Pawn(_team, _startingPosition);
                break;
            case Weeble.Type.Diag:
                weeb = new Diag(_team, _startingPosition);
                break;
            case Weeble.Type.Mimic:
                weeb = new Mimic(_team, _startingPosition);
                break;
            case Weeble.Type.Scout:
                weeb = new Scout(_team, _startingPosition);
                break;
            case Weeble.Type.King:
                weeb = new King(_team, _startingPosition);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Camera.main.transform.rotation;
    }
    public bool MoveGreeble(Vector3Int newCoordinate)
    {
        if (weeb.isValidMove(newCoordinate))
        {
            //dotween
            transform.DOMove(HexTile.GridToWorldspace(new Vector3Int(newCoordinate.x, newCoordinate.y, newCoordinate.z)), 0.5f);
            weeb.setCoordinates(newCoordinate);
            return true;
        }
        return false;
    }
}
