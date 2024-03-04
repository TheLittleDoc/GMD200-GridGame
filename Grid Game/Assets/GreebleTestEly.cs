using System.Collections;
using System.Collections.Generic;
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
}
