using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GreebleTestEly : MonoBehaviour
{

    [SerializeField] private Vector3Int _startingPosition;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = HexTile.GridToWorldspace(new Vector3Int(_startingPosition.x, _startingPosition.y, _startingPosition.z));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void MoveGreeble(Vector3Int newCoordinate)
    {
        //dotween
        
        transform.DOMove(HexTile.GridToWorldspace(new Vector3Int(newCoordinate.x, newCoordinate.y, newCoordinate.z)), 0.5f);
        
        //transform.position = HexTile.GridToWorldspace(new Vector3Int(newCoordinate.x, newCoordinate.y, newCoordinate.z));
    }
}
