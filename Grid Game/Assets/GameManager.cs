using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //singleton
    public static GameManager instance;
    public bool isGameOver = false;
    public GameObject[] listOfGreebles;
    public GameObject[] listOfWugs;
    private bool _isPopulated = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
        //make singleton
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
        GetComponent<AudioSource>().Play();
        
    }

    private void OnEnable()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        listOfGreebles = GameObject.FindGameObjectsWithTag("Greeble");
        listOfWugs = GameObject.FindGameObjectsWithTag("Wug");
        
        
        
        // count of tag greebles not dead
        // if count is 0, game over
        if (isGameOver)
            return;
        for(int i = 0; i < listOfGreebles.Length; i++)
        {
            Debug.Log(listOfGreebles[i]);
            if (listOfGreebles[i].GetComponent<GamePiece>().thisWeeble.IsDead() == false)
            {
                //remove dead greebles from list
                listOfGreebles[i] = null;
                
            }
        }
        for(int i = 0; i < listOfWugs.Length; i++)
        {
            if (listOfWugs[i].GetComponent<GamePiece>().thisWeeble.IsDead() == false)
            {
                //remove dead wugs from list
                listOfWugs[i] = null;
            }
        }
        
        Debug.Log("Greebles: " + listOfGreebles.Length + " Wugs: " + listOfWugs.Length);
    }

    void StartGame()
    {
        listOfGreebles = GameObject.FindGameObjectsWithTag("Greeble");
        listOfWugs = GameObject.FindGameObjectsWithTag("Wug");
    }
}
